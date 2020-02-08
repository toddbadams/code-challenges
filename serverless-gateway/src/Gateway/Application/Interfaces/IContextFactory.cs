using System.Net.Http;
using Gateway.Application.Contexts;
using Gateway.Application.Pipelines;

namespace Gateway.Application.Interfaces
{
    public interface IContextFactory
    {
        Context Create(string key, HttpRequestMessage req);
    }
}