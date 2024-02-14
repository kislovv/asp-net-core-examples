using System.Net;

namespace Pipeline;

public interface IMiddleware
{
    public IMiddleware Next { get; }
    public Task Invoke(HttpListenerContext context);
}