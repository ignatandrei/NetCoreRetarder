using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace NetCoreRetarderCore
{
    public class RetarderMiddleware : IMiddleware
    {

        public RetarderMiddleware()
        {
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var random = new Random();
            var awaitMilliseconds = random.Next(1, 1000);
            Console.WriteLine($"awaiting {awaitMilliseconds}");
            await Task.Delay(awaitMilliseconds);
            Console.WriteLine($"***awaited {awaitMilliseconds}");

            await next(context);
        }
    }
}
