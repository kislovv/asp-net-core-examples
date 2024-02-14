using System.Net;

namespace Pipeline;

public class CheckMethodMiddleware : IMiddleware
{
    public IMiddleware Next { get; }
    public async Task Invoke(HttpListenerContext context)
    {
        Console.WriteLine(context.Request.HttpMethod);
    }
}