using Gateway.Application.Interfaces;

namespace Gateway.Application.Middleware
{
    public class MiddlewareFactory : IMiddlewareFactory
    {
        readonly ISecretsProvider _secretsProvider;

        public MiddlewareFactory(ISecretsProvider secretsProvider)
        {
            _secretsProvider = secretsProvider;
        }

        public MiddlewareBase CorrelationId() => new CorrelationIdMiddleware();
        public MiddlewareBase FunctionHostKey() => new FunctionHostKeyMiddleware(_secretsProvider);
    }
}
