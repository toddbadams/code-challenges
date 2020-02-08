using Gateway.Application.Middleware;

namespace Gateway.Application.Interfaces
{
    public interface IMiddlewareFactory
    {
        CorrelationIdMiddleware CorrelationId();
        FunctionHostKeyMiddleware FunctionHostKey();
    }
}