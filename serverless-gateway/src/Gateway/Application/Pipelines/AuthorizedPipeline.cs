using Gateway.Application.Interfaces;
using Gateway.Application.Middleware;

namespace Gateway.Application.Pipelines
{
    public class AuthorizedPipeline : Pipeline
    {
        public AuthorizedPipeline(IContextFactory contextFactory, IMiddlewareFactory middlewareFactory) : base(contextFactory)
        {
            Register(middlewareFactory.CorrelationId());
            Register(middlewareFactory.FunctionHostKey());
        }
    }
}