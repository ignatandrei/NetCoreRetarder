using FluentAssertions;
using LightBDD.XUnit2;
using NetCoreRetarderCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreRetarderTest
{
    public partial class TestStrategyAwait: FeatureFixture
    {
        int delay = 0;
  
        IStrategyAwait st;
        private async Task When_Choosing_Fixed_Await_For_NRSECONDS_Seconds(int nrSeconds)
        {

            st = new StrategyAwaitFixed(nrSeconds*1000);
            await Task.Delay(1);
        }
        private async Task When_Choosing_Random_Await_Between_MIN_And_MAX_Seconds(int min, int max)
        {

            st = new StrategyAwaitRandom(min * 1000, max*1000);
            await Task.Delay(1);
        }
        private async Task<int> And_Await()
        {
            var sp= new Stopwatch();
            sp.Start();
            await st.AwaitDelayBefore();
            sp.Stop();
            delay =(int) sp.ElapsedMilliseconds / 1000;
            return delay;
        }
        private async Task Then_Time_Ellapsed_Will_Be_Between_MIN_And_MAX_Seconds(int min, int max)
        {
            await Task.Delay(1);
            if(min>max)
            {
                var x = min;
                min = max;
                max = min;
            }
            delay.Should().BeInRange(min,max);
        }
        private async Task Then_Time_Ellapsed_Will_Be_NRSECONDS_Seconds(int nrSeconds)
        {
            await Task.Delay(1);
            delay.Should().Be(nrSeconds);
            //            delay.Should().BeInRange(1, 2);
        }

    }
}
