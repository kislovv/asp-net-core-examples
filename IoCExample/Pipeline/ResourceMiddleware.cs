using System.Net;

namespace Pipeline;

public class ResourceMiddleware : IMiddleware
{
    public IMiddleware Next { get; }
    public async Task Invoke(HttpListenerContext context)
    {
        Console.WriteLine(context.Request.RawUrl);
    }
}