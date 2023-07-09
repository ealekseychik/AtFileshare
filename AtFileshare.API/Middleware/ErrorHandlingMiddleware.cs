namespace AtFileshare.API.Middleware
{
    using FluentValidation;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Text.Json;

    public class ErrorHandlingMiddleware
    {
        private const string JsonContentType = "application/json";
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = GetStatusCode(ex);
            context.Response.ContentType = JsonContentType;

            return context.Response.WriteAsync(
                JsonSerializer.Serialize(new
                {
                    errors = GetErrors(ex)
                }));
        }

        private static int GetStatusCode(Exception exception) =>
        exception switch
        {
            ValidationException => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        private static IReadOnlyDictionary<string, string[]> GetErrors(Exception exception)
        {
            IReadOnlyDictionary<string, string[]> errors = null;
            if (exception is ValidationException validationException)
            {
                errors = validationException.Errors
                    .GroupBy(
                        x => x.PropertyName,
                        x => x.ErrorMessage,
                        (propertyName, errorMessages) => new
                        {
                            Key = propertyName,
                            Values = errorMessages.Distinct().ToArray()
                        })
                    .ToDictionary(x => x.Key, x => x.Values);
            }

            return errors;
        }
    }
}
