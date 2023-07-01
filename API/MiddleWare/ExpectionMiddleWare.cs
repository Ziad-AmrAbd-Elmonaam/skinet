
using System.Net;
using System.Text.Json;
using API.Errors;

namespace API.MiddleWare
{
    public class ExpectionMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExpectionMiddleWare> _logger;
        private readonly IHostEnvironment _env;

        public ExpectionMiddleWare(RequestDelegate next, ILogger<ExpectionMiddleWare> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = _env.IsDevelopment() ? new ApiExpection((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString()) : new ApiExpection((int)HttpStatusCode.InternalServerError);
                var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
                var json = JsonSerializer.Serialize(response,options);
                await context.Response.WriteAsync(json);
            }

        }
    }

}
