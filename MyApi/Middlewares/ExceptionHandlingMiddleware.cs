using Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace MyApi.Middlewares;

internal sealed class ExceptionHandlingMiddleware(
    ILogger<ExceptionHandlingMiddleware> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var traceId = httpContext.TraceIdentifier;

        logger.LogError(exception, "Unhandled exception. TraceId: {TraceId}", traceId);

        var (statusCode, code, message) = exception switch
        {
            ValidationException ex => (
                StatusCodes.Status400BadRequest,
                "VALIDATION_ERROR",
                ex.Message
            ),

            NotFoundException ex => (
                StatusCodes.Status404NotFound,
                "NOT_FOUND",
                ex.Message
            ),

            ConflictException ex => (
                StatusCodes.Status409Conflict,
                "CONFLICT",
                ex.Message
            ),

            DbUpdateConcurrencyException => (
                StatusCodes.Status409Conflict,
                "CONCURRENCY_CONFLICT",
                "The resource was modified by another process."
            ),

            _ => (
                StatusCodes.Status500InternalServerError,
                "INTERNAL_SERVER_ERROR",
                "An unexpected error occurred."
            )
        };

        httpContext.Response.StatusCode = statusCode;
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.Headers["X-Trace-Id"] = traceId;

        var response = new
        {
            code,
            message,
            traceId
        };

        await httpContext.Response.WriteAsync(
            JsonSerializer.Serialize(response),
            cancellationToken
        );

        return true;
    }
}
