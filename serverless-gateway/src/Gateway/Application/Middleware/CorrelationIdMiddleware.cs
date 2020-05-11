using System;
using System.Linq;
using System.Threading.Tasks;
using Gateway.Application.Contexts;

namespace Gateway.Application.Middleware
{
    /// <summary>
    /// Reads an incoming header `X-Request-ID` and applies that to the downstream request.
    /// If the header is absent a GUID value is generated.
    /// </summary>
    public class CorrelationIdMiddleware : MiddlewareBase
    {
        private const string Header = "Request-Id";
        public override Task InvokeAsync(IContext httpContext)
        {
            var headers = httpContext.Request.Headers;
            if (!headers.Contains(Header) || headers.GetValues(Header) == null)
            {
                httpContext.DownstreamRequest.Headers.Add(Header, Guid.NewGuid().ToString());
                return Task.Delay(0);
            } 
            httpContext.DownstreamRequest.Headers.Add(Header, httpContext.Request.Headers.GetValues("Request-Id").First());
            return Task.Delay(0);
        }
    }
}