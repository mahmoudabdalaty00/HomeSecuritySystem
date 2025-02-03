using HomeSecuritySystem.Api.Models;
using HomeSecuritySystem.Application.Exceptions;
using System.Net;

namespace HomeSecuritySystem.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // If there is no exception, the request is passed to the next middleware
                await _next(context);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(context, ex);

                /*
                // If there is an exception, the response is set to 500 Internal Server Error
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                // The exception is logged
                _logger.LogError($"Something went wrong: {ex}");
                // The response is written to the context
                await context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Internal Server Error. Please try again later."
                }.ToString());

                */
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            CustomProblemDetails problem = new();
            switch (ex)
            {
                case BadRequestException badRequest:
                    statusCode = HttpStatusCode.BadRequest;
                    problem = new CustomProblemDetails
                    {

                        // Errors = badRequest.ValidationErrors as IDictionary<string, string[]>,
                        Title = badRequest.Message,
                        Status = (int)statusCode,           
                        Instance = context.Request.Path,
                        Type = nameof(BadRequestException),
                        Extensions = {
                            { "Errors", badRequest.ValidationErrors }
                                      },
                        Detail = badRequest.InnerException?.Message,

                    };
                    break;

                case NotFoundException notFound:
                    statusCode = HttpStatusCode.NotFound;
                    problem = new CustomProblemDetails
                    {
                        Status = (int)statusCode,
                        Title = notFound.Message,
                        Instance = context.Request.Path,
                        Type = nameof(NotFoundException),
                        Extensions = {
                            { "Errors", notFound.Message }
                                      },
                        Detail = notFound.InnerException?.Message,

                    };
                    break;

                default:
                    problem = new CustomProblemDetails
                    {
                        Status = (int)statusCode,
                        Title = ex.Message,
                        Instance = context.Request.Path,
                        Type = nameof(HttpStatusCode.InternalServerError),
                        Extensions = {
                            { "Errors", ex.Message }
                                      },
                        Detail = ex.StackTrace,
                    };
                    break;

            }
            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}
