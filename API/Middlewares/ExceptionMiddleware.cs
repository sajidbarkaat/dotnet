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
        catch (Exception error)
        {
            this.logger.LogError(error, error.Message);
            var response = httpContext.Response;
            response.ContentType = "application/json";

            switch (error)
            {              
                case KeyNotFoundException e:
                    // not found error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    // unhandled error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(new { message = error?.Message });
            await response.WriteAsync(result);
        }
    }
}
