
[Microservices Architecture](https://microservices.io/patterns/apigateway.html) defines the gateway pattern as a means for clients of the architecture to use individual services. 


# Azure functions serverless gateway

As a proof of concept this project creates a gateway pattern using Azure serverless tehcnonolgy (Function Apps).  

This is accomplished by creating a single Azure Function App with an API class for each downstream service. For example `WinesApi` takes incomming a `HttpRequestMessage` and passes that to the pipeline with a name (aka key).  The key is used as a convention based look up onto a configuration store to retrieve the location of the downstream service. 

``` csharp
public class WinesApi
    {
        private const string Name = "wines";
        private readonly Pipeline _pipeline;

        public WinesApi(IPipelineFactory pipelineFactory)
        {
            _pipeline = pipelineFactory.Authorized();
        }

        [FunctionName(Name + "-get")]
        public async Task<HttpResponseMessage> Get(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = Name + "/{wineId?}")]
            HttpRequestMessage req) => await _pipeline.ExecuteAsync(Name, req);

        [FunctionName(Name + "-post")]
        public async Task<HttpResponseMessage> Post(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = Name)]
            HttpRequestMessage req) => await _pipeline.ExecuteAsync(Name, req);

        [FunctionName(Name + "-put")]
        public async Task<HttpResponseMessage> Put(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = Name + "/{wineId}")]
            HttpRequestMessage req) => await _pipeline.ExecuteAsync(Name, req);

        [FunctionName(Name + "-delete")]
        public async Task<HttpResponseMessage> Delete(
            [HttpTrigger(AuthorizationLevel.Anonymous,  "delete", Route = Name + "/{wineId}")]
            HttpRequestMessage req) => await _pipeline.ExecuteAsync(Name, req);
    }
```

The approach creates a downstream request and then uses a pipeline to process the incomming request and build up the downstream request.

## Pipeline
A pipeline is a set of middleware that is run one after another. Each instance of the pipeline registers the middleware to run as:

``` csharp
 public class AuthorizedPipeline : Pipeline
    {
        public AuthorizedPipeline(IContextFactory contextFactory, IMiddlewareFactory middlewareFactory) : base(contextFactory)
        {
            Register(middlewareFactory.CorrelationId());
            Register(middlewareFactory.FunctionHostKey());
        }
    }
```

The pipline baseclass then allows it to be executed as:

``` csharp
        public async Task<HttpResponseMessage> ExecuteAsync(string key, HttpRequestMessage req)
        {
            if (!_pipeline.Any()) throw new MiddlewareException();

            // create a context that is used throughout the pipeline
            var context = _contextFactory.Create(key, req);

            try
            {
                foreach (var middleware in _pipeline)
                {
                    // the the middleware on the context
                    await middleware.InvokeAsync(context);
                }
            }
            catch (Exception e)
            {
                return context?.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }

            return await context.SendAsync();
        }

```

## Middleware
Each pipeline constists of a number of middleware operations that are run squentially against the incomming request to form the downstream request. The `MiddlewareFactory` is used to create specific middelware instances. The middleware can be created and invoked as:

``` c-sharp
     middlewareFactory.CorrelationId().Invoke(context);
``` 

The following two middeware classes have been created, and other can be added to suite the needs of downstream services. 

### Correlation Id Middleware
The `CorrelationIdMiddleware` class reads an incoming header `X-Request-ID` and applies that to the downstream request. If the header is absent a GUID value is generated.

```
X-Request-ID: 94836156-78ac-4b9d-9beb-01786f975f12
```

### Function Host Key Middleware
Azure Functions provide protected access to HTTP triggered functions by means of authorization keys. Each function has an authorization level set as an attribute; anonymous requires no API key, function requires a function specific API key. 

The `FunctionHostKeyMiddleware` class adds the specific downstream function authoriziation key as a header, for example:

```
x-functions-key: VyEOe9oIHkIz6sj+Are3ffHcP7ptHKAidUAxgDMkdSSaYuGDraek5Q==
```


## Routing
Routes incoming requests to a downstream service. 

### Example
In this example an anonymous endpoint is created that supports `GET` method.  The incoming route is given by `wines/{wineId?}`, this allows and optional routing parameter of the wine identifier.

The downstream service configuration is given by the string array `"wines-v1", "wines-v2"`.  This then retrieves the following convention based settings from Azure Configuration Management.
- `wines-v1-route`: /api/v1/wines/{wineId?}
- `wines-v1-scheme`: https
- `wines-v1-host`: localhost
- `wines-v1-port`: 80
- `wines-v1-event`: false  // disables event logging
- `wines-v2-route`: /api/v2/wines/{wineId?}
- `wines-v2-scheme`: https
- `wines-v2-host`: localhost
- `wines-v2-port`: 80
- `wines-v2-event`: true  // enables event logging


## Authorization (to be done, not yet coded)

Claims based authorization using [JWT](https://jwt.io/introduction/).  The incomming authorization token has it's signature verified, and expresses all claims as headers to the downstream service.

### Incoming authorization header

``` json
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhNzZjMzcxYy01MzU0LTQ0ZjUtYTljZC01ZWNiZDQ2NGQ1ODIiLCJuYW1lIjoiSm9obiBEb2UiLCJpYXQiOjE1MTYyMzkwMjJ9.zM1cC8DaLEmP1KB0QKP8u5nL9u_sa2Z-Ce8oVsZXsag
```

this has the following payload:

``` json
{
  "sub": "a76c371c-5354-44f5-a9cd-5ecbd464d582",
  "name": "John Doe",
  "iat": 1516239022
}
```
### Downstream headers
The incoming claims are expressed as headers in the downstream request as:

``` json
x-jwt-sub: a76c371c-5354-44f5-a9cd-5ecbd464d582
x-jwt-name: John Doe
x-jwt-iat: 1516239022
```
