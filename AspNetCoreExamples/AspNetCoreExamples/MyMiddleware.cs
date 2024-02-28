namespace AspNetCoreExamples;

public class MyMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        Console.WriteLine("Test");
        await next(context);
    }
}