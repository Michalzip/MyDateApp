
using Microsoft.Extensions.Caching.Memory;

namespace DateApp.Infrastructure.Middlewares
{
    public class JwtAuthenticationMiddleware : IMiddleware
    {
        private readonly IMemoryCache _cache;

        public JwtAuthenticationMiddleware(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var token = _cache.Get<string>("jwtToken");

            if (!string.IsNullOrEmpty(token))
            {
                context.Request.Headers.Add("Authorization", $"Bearer {token}");
            }

            await next(context);
        }
    }
}