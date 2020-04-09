using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;
using System;
using System.Threading.Tasks;
using Xunit;
[assembly: LightBddScope]

namespace NetCoreRetarderTest
{
    //https://github.com/LightBDD/LightBDD/wiki/Formatting-Parameterized-Steps

    [FeatureDescription(

   @"This will test just how 

will await a determined number of time
")]
    public partial class TestStrategyAwaitFixed
    {
        
        [Scenario]

        [Label("wait times")]

        [ScenarioCategory("Wait")]
        [InlineData(3)]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]

        public async Task WaitTime(int nrSeconds)

        {

            await Runner.RunScenarioAsync(

                    _ => When_Choosing_Fixed_Await_For_NRSECONDS_Seconds(nrSeconds),

                    _=> AndAwait(),

                    _=> Then_Time_Ellapsed_Will_Be_NRSECONDS_Seconds(nrSeconds)
                    )

                ;

        }
    }
}
