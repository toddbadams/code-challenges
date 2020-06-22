using System.Net.Http;
using System.Threading.Tasks;

namespace Gateway.Application.Contexts
{
    public interface IContext
    {
        HttpClient HttpClient { get; }
        HttpRequestMessage Request { get; }
        HttpRequestMessage DownstreamRequest { get; }
        Task<HttpResponseMessage> SendAsync(); 
        string DownstreamKey { get; }
    }
}