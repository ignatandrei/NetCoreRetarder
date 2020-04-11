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
    public partial class TestStrategyAwait
    {
        
        [Scenario]

        [Label("wait times fixed")]

        [Trait("Category", "Wait")]
        [InlineData(3)]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]

        public async Task WaitTime(int nrSeconds)

        {
           
            await Runner.RunScenarioAsync(

                    _ => When_Choosing_Fixed_Await_For_NRSECONDS_Seconds(nrSeconds),

                    _=> And_Await(),

                    _=> Then_Time_Ellapsed_Will_Be_NRSECONDS_Seconds(Math.Max(nrSeconds, 0))
                    )

                ;

        }
        [Scenario]

        [Label("wait times random")]

        [ScenarioCategory("Wait")]
        [InlineData(3,1)]
        [InlineData(1,2)]
        [InlineData(0,1)]
        [InlineData(-1,5)]

        public async Task WaitTimeRandom(int min,int max)

        {

            await Runner.RunScenarioAsync(

                    _ => When_Choosing_Random_Await_Between_MIN_And_MAX_Seconds(min,max),

                    _ => And_Await(),

                    _ => Then_Time_Ellapsed_Will_Be_Between_MIN_And_MAX_Seconds(Math.Max(min, 0),Math.Max(max,0))
                    )

                ;

        }
    }
}
