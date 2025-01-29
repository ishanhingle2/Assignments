using System.Net;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Http;
namespace Stocks.API.Middlewares;

public class GlobalExceptionHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = HttpStatusCode.InternalServerError; 
        string message;

        switch (exception)
        {
            case ArgumentNullException:
                statusCode = HttpStatusCode.BadRequest;
                message = "One or more required arguments are missing";
                break;

            case MySqlException:
                statusCode = HttpStatusCode.InternalServerError;
                message = "Database error occurred";
                break;

            case KeyNotFoundException:
                statusCode = HttpStatusCode.NotFound;
                message = "Resource not found";
                break;

            case ArgumentException _:
                statusCode = HttpStatusCode.BadRequest;
                message = "Invalid argument provided";
                break;

            case TimeoutException _:
                statusCode = HttpStatusCode.RequestTimeout;
                message = "Request timed out";
                break;

            default:
                statusCode = HttpStatusCode.InternalServerError;
                message = "An unexpected error occurred";
                break;
        }
        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";

        var result = new { message = message };
        await context.Response.WriteAsJsonAsync(result);
    }
}