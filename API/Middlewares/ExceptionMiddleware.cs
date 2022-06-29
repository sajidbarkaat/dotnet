using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Middlewares;

public class ExceptionMiddleware
{
    private RequestDelegate requestDelegate;
    private ILogger<ExceptionMiddleware> logger;

    private IHostEnvironment env;

    public ExceptionMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionMiddleware> logger, IHostEnvironment env) 
    {
        this.requestDelegate = requestDelegate;
        this.logger = logger;
        this.env = env;
    }

    public async Task InvokeAsync(HttpContext httpContext) 
    {
        try
        {
            await this.requestDelegate(httpContext);
        }
        catch (Exception exception)        
        {
            this.logger.LogError(exception, exception.Message);
            httpContext.Response.ContentType = "";
            httpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

            //StatusCode, Message, Details
            var response = new { StatusCode = httpContext.Response.StatusCode, Message = "Internal Server Error"};
            var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
            var json = JsonSerializer.Serialize(response, options);
            await httpContext.Response.WriteAsync(json);
        }
    }    
}
