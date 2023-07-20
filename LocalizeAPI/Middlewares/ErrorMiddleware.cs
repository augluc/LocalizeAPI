using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LocalizeAPI.Middlewares;

public class ErrorMiddleware
{
    private RequestDelegate _next;

    public ErrorMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);

        }
        catch (InvalidUserCredentialsException ex)
        {
            await CreateErrorResponse(context, (int)HttpStatusCode.Unauthorized, "Login Unauthorized", ex.Message);

        }
        catch (NotFoundException ex)
        {
            await CreateErrorResponse(context, (int)HttpStatusCode.NotFound, "Not Found", ex.Message);

        }
        catch (Exception ex)
        {
            await CreateErrorResponse(context, (int)HttpStatusCode.InternalServerError, "Unexpected Error", ex.Message);

        }

    }

    public async Task CreateErrorResponse(HttpContext context, int statusCode, string title, string detail)
    {
        context.Response.StatusCode = statusCode;

        var problemDetails = new ProblemDetails();

        problemDetails.Status = statusCode;
        problemDetails.Title = title;
        problemDetails.Detail = detail;

        await context.Response.WriteAsJsonAsync(problemDetails);
    }
}