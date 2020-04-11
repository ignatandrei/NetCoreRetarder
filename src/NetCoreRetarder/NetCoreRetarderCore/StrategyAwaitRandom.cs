using System;
using System.Threading.Tasks;

namespace NetCoreRetarderCore
{
    public class StrategyAwaitRandom : IStrategyAwait
    {
        StrategyAwaitFixed sf;
        public StrategyAwaitRandom(int min,int max)
        {
            if (min > max)
            {
                var x = min;
                min = max;
                max = min;
            }
            var random = new Random();
            var awaitTime = random.Next(min, max);
            sf = new StrategyAwaitFixed(awaitTime);
        }
        public Task<IStrategyAwait> AwaitDelayAfter()
        {
            return sf.AwaitDelayAfter();
        }

        public Task<IStrategyAwait> AwaitDelayBefore()
        {
            return sf.AwaitDelayBefore();
        }
    }
}
