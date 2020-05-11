using System.Net.Http;
using Gateway.Application.Interfaces;

namespace Gateway.Application.Contexts
{
    public class ContextFactory : IContextFactory
    {
        private readonly IConfigurationProvider _config;
        private readonly HttpClient _httpClient;

        public ContextFactory(IConfigurationProvider config, HttpClient httpClient)
        {
            _config = config;
            _httpClient = httpClient;
        }

        public IContext Create(string key, HttpRequestMessage req) =>
            new Context(req, _config, key, _httpClient);
    }
}