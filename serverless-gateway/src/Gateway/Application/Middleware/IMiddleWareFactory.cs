namespace Gateway.Application.Middleware
{
    public interface IMiddlewareFactory
    {
        MiddlewareBase CorrelationId();
        MiddlewareBase FunctionHostKey();
    }
}