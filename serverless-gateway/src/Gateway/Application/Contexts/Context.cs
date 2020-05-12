using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Gateway.Application.Interfaces;

namespace Gateway.Application.Contexts
{
    public class Context : IContext
    {
        private readonly IConfigurationProvider _configurationProvider;
        public string DownstreamKey { get; }

        public HttpClient HttpClient { get; }

        public HttpRequestMessage Request { get; }

        public HttpRequestMessage DownstreamRequest { get; }

        public Context(HttpRequestMessage request, IConfigurationProvider configurationProvider,
            string key, HttpClient httpClient)
        {
            _configurationProvider = configurationProvider;
            Request = request;
            DownstreamKey = key;
            HttpClient = httpClient;
            DownstreamRequest = new HttpRequestMessage(request.Method, Uri);

            if (request.Headers.TryGetValues("ContentType", out var values))
            {
                DownstreamRequest.Headers.Add("ContentType", string.Join(",", values.ToArray()));
            }

            DownstreamRequest.Content = Request.Content;
        }

        public async Task<HttpResponseMessage> SendAsync() => await HttpClient.SendAsync(DownstreamRequest);

        private string Uri =>
            $"{Value("scheme")}://{Value("host")}:{Value("port")}{Value("route")}";

        private string Value(string name) => _configurationProvider.Get($"{DownstreamKey}-{name}");
    }
}