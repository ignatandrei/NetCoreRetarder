using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreRetarderCore
{
    public static class RetarderExtensions
    {
        public static void AddRetarder(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<RetarderMiddleware>();
        }
        public static void UseRetarder(this IApplicationBuilder app)
        {
            app.UseMiddleware<RetarderMiddleware>();
        }

    }
}
