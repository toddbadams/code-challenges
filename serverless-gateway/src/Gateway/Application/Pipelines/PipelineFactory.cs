using Gateway.Application.Interfaces;

namespace Gateway.Application.Pipelines
{
    public class PipelineFactory : IPipelineFactory
    {
        private readonly IMiddlewareFactory _middlewareFactory;
        private readonly IContextFactory _contextFactory;

        public PipelineFactory(IMiddlewareFactory middlewareFactory,
            IContextFactory contextFactory)
        {
            _middlewareFactory = middlewareFactory;
            _contextFactory = contextFactory;
        }

        /// <summary>
        /// Create the authorized endpoint pipeline
        /// </summary>
        public Pipeline Authorized() => new AuthorizedPipeline(_contextFactory, _middlewareFactory);
    }
}