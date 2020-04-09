using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace NetCoreRetarderCore
{
    public class RetarderMiddleware : IMiddleware
    {
        private IStrategyAwait strategyAwait;

        public RetarderMiddleware(IStrategyAwait strategyAwait)
        {
            this.strategyAwait = strategyAwait;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            while (strategyAwait != null)
                strategyAwait = await strategyAwait?.AwaitDelay();
            
            await next(context);
            
        }
    }
}
