using System.Net.Http;
using Gateway.Application.Contexts;

namespace Gateway.Application.Interfaces
{
    public interface IContextFactory
    {
        IContext Create(string key, HttpRequestMessage req);
    }
}