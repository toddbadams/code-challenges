using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using wine_libarary_application.Commands;

namespace WL.PresentationCommands
{
    public interface IRequestProcessor
    {
        Task<IActionResult> ProcessRequest(string name, Func<Task<CommandBase>> func, IAsyncCollector<Message> messages);
        Task<IActionResult> ProcessRequest(string name, Func<CommandBase> func, IAsyncCollector<Message> messages);
        Task<T> ReadBodyAsync<T>(HttpRequest req);
    }
}