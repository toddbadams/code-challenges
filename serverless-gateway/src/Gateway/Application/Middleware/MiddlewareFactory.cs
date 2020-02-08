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

        public CorrelationIdMiddleware CorrelationId() => new CorrelationIdMiddleware();
        public FunctionHostKeyMiddleware FunctionHostKey() => new FunctionHostKeyMiddleware(_secretsProvider);
    }
}
