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
            var st = strategyAwait;
            while (st != null)
                st = await st.AwaitDelayBefore();
            
            await next(context);
            st = strategyAwait;

            while (st != null)
                st = await st.AwaitDelayAfter();


        }
    }
}
