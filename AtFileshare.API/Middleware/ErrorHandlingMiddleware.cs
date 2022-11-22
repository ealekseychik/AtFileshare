namespace AtFileshare.API.Middleware
{
    using FluentValidation;
    using System.Net;
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
            int httpStatusCode;
            string message;

            switch (ex)
            {
                case var _ when ex is ValidationException:
                    httpStatusCode = (int)HttpStatusCode.BadRequest;
                    message = ex.Message;
                    break;
                default:
                    httpStatusCode = (int)HttpStatusCode.InternalServerError;
                    message = "An error occured while processing your request.";
                    break;
            }

            context.Response.StatusCode = httpStatusCode;
            context.Response.ContentType = JsonContentType;

            return context.Response.WriteAsync(
                JsonSerializer.Serialize(new
                { 
                    error = message
                }));
        }
    }
}
