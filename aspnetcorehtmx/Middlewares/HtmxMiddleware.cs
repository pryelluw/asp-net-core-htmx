using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;


public class HtmxMiddleware 
{
    private readonly RequestDelegate _next;

    public HtmxMiddleware(RequestDelegate next) 
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context) 
    {
        context.Request.Headers.TryGetValue("HX-Request", out var isHtmxRequest);
        if(string.IsNullOrEmpty(isHtmxRequest)) 
        {
            context.Items["isHtmxRequest"] = false;
        }
        else 
        {
            context.Items["isHtmxRequest"] = true;
        } 
        await _next(context);
    }
}