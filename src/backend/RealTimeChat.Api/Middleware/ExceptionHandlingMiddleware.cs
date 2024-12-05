namespace RealTimeChat.Api.Middleware;

public class ExceptionHandlingMiddleware(
    RequestDelegate next,
    ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var response = new 
            {
                StatusCode = context.Response.StatusCode,
                Message = "An unexpected error occurred"
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}