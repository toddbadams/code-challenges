using System.Threading.Tasks;
using Gateway.Application.Contexts;
using Gateway.Application.Interfaces;

namespace Gateway.Application.Middleware
{
    public class FunctionHostKeyMiddleware : MiddlewareBase
    {
        private const string FunctionHostHeaderKey = "x-functions-key";
        private readonly ISecretsProvider _secretsProvider;

        public FunctionHostKeyMiddleware(ISecretsProvider secretsProvider)
        {
            _secretsProvider = secretsProvider;
        }

        public override async Task InvokeAsync(IContext httpContext)
        {
            var key = await _secretsProvider.Get($"{httpContext.DownstreamKey}-functionHostKey");
            httpContext.DownstreamRequest.Headers.Add(FunctionHostHeaderKey, key);
        }
    }
}