using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gateway.Application.Contexts
{
    public interface IContext
    {
        HttpClient HttpClient { get; }
        HttpRequestMessage Request { get; }
        HttpRequestMessage DownstreamRequest { get; }
        IDictionary<string, string> Properties { get; }
        Task<HttpResponseMessage> SendAsync(); 
        string DownstreamKey { get; }
    }
}