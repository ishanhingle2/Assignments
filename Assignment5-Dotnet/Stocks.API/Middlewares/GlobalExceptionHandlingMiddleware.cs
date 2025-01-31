using System.Net;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
namespace Stocks.API.Middlewares;

public class GlobalExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;
    public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger){
        _logger=logger;
    }
    public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception: {Message},\n StackTrace: {StackTrace}", ex.Message, ex.StackTrace);
            await HandleExceptionAsync(httpContext, ex);
        }
    }
    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = HttpStatusCode.InternalServerError;
        string message=exception.Message;
        switch (exception)
        {
            case ArgumentNullException:
                statusCode = HttpStatusCode.BadRequest;
                break;

            case MySqlException:
                statusCode = HttpStatusCode.InternalServerError;
                break;

            case KeyNotFoundException:
                statusCode = HttpStatusCode.NotFound;
                break;

            case ArgumentException _:
                statusCode = HttpStatusCode.BadRequest;
                break;

            case TimeoutException _:
                statusCode = HttpStatusCode.RequestTimeout;
                break;

            case ValidationException:
                statusCode = HttpStatusCode.BadRequest;
                break;

            default:
                statusCode = HttpStatusCode.InternalServerError;
                break;
        }
        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";

        var result = new { message = message };
        await context.Response.WriteAsJsonAsync(result);
    }
}