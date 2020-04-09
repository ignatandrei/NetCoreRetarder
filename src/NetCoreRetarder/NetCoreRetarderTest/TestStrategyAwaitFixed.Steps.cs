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
    public partial class TestStrategyAwaitFixed: FeatureFixture
    {
        int delay = 0;
  
        IStrategyAwait st;
        private async Task When_Choosing_Fixed_Await_For_NRSECONDS_Seconds(int nrSeconds)
        {
            st = new StrategyAwaitFixed(nrSeconds*1000);
        }
        private async Task AndAwait()
        {
            var sp= new Stopwatch();
            sp.Start();
            await st.AwaitDelay();
            sp.Stop();
            delay =(int) sp.ElapsedMilliseconds / 1000;
        }
        private async Task Then_Time_Ellapsed_Will_Be_NRSECONDS_Seconds(int nrSeconds)
        {
            delay.Should().Be(Math.Max(nrSeconds,0) );
//            delay.Should().BeInRange(1, 2);
        }

    }
}
