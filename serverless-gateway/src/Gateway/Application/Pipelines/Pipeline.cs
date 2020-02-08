using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Gateway.Application.Interfaces;
using Gateway.Application.Middleware;

namespace Gateway.Application.Pipelines
{
    public abstract class Pipeline
    {
        private readonly IContextFactory _contextFactory;
        private readonly List<MiddlewareBase> _pipeline;

        internal Pipeline(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _pipeline = new List<MiddlewareBase>();
        }

        /// <summary>
        /// Register a middle ware in the pipeline
        /// </summary>
        protected void Register(MiddlewareBase middlewareBase) => _pipeline.Add(middlewareBase);

        /// <summary>
        /// Execute the pipeline
        /// </summary>
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
    }
}