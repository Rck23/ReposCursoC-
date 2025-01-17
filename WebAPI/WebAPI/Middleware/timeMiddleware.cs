class timeMiddleware
{
    readonly RequestDelegate next;

    public timeMiddleware(RequestDelegate nextRequest)
    {
        next = nextRequest;
    }

    public async Task Invoke(HttpContext http)
    {
        await next(http);

        if (http.Request.Query.Any(x => x.Key == "time"))
        {
            await http.Response.WriteAsync(DateTime.Now.ToShortDateString());
        }
    }

}
public static class timeMiddlewareExtension
{
    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<timeMiddleware>();
    }
}