using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreRetarder
{
    public class RetarderMiddleware : IMiddleware
    {

        public RetarderMiddleware()
        {
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var random = new Random();
            //var awaitMilliseconds =random.Next(10000, 100000);
            var awaitMilliseconds = random.Next(1, 1000);
            Console.WriteLine($"awaiting {awaitMilliseconds}");
            await Task.Delay(awaitMilliseconds);
            Console.WriteLine($"***awaited {awaitMilliseconds}");

            await next(context);
        }
    }
}
