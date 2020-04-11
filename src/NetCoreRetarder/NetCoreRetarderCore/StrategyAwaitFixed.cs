using System;
using System.Threading.Tasks;

namespace NetCoreRetarderCore
{
    public class StrategyAwaitFixed : IStrategyAwait
    {
        private readonly int milliseconds;

        public StrategyAwaitFixed(int milliseconds)
        {
            this.milliseconds = milliseconds;
        }

        public Task<IStrategyAwait> AwaitDelayAfter()
        {
            return null;
        }

        public async Task<IStrategyAwait> AwaitDelayBefore()
        {
            Console.WriteLine($"waiting {milliseconds}");
            
            if (milliseconds < 1)
                return null;

            await Task.Delay(milliseconds);
            
            Console.WriteLine($"finished waiting {milliseconds}");
            
            return null;
        }
    }
}
