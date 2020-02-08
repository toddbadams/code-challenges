using System.Threading.Tasks;
using Gateway.Application.Contexts;

namespace Gateway.Application.Middleware
{
    public abstract class MiddlewareBase
    {
        public abstract Task InvokeAsync(Context httpContext);
        public MiddlewareBase Next { get; set; }
    }
}