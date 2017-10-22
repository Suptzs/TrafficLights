using TrafficLightsControlSystem;
using Xunit;

namespace TrafficLightsTests
{
    public class CrossingValidatorTest
    {
        [Theory]
        [InlineData(LightState.Green, LightState.Red, true)]
        [InlineData(LightState.Yellow, LightState.Red, true)]
        [InlineData(LightState.Red, LightState.Red, true)]
        [InlineData(LightState.RedYellow, LightState.Red, true)]
        [InlineData(LightState.Unknown, LightState.Red, false)]
        
        [InlineData(LightState.Green, LightState.Green, false)]
        [InlineData(LightState.Yellow, LightState.Green, false)]
        [InlineData(LightState.Red, LightState.Green, true)]
        [InlineData(LightState.RedYellow, LightState.Green, false)]
        [InlineData(LightState.Unknown, LightState.Green, false)]
        
        [InlineData(LightState.Green, LightState.RedYellow, false)]
        [InlineData(LightState.Yellow, LightState.RedYellow, false)]
        [InlineData(LightState.Red, LightState.RedYellow, true)]
        [InlineData(LightState.RedYellow, LightState.RedYellow, false)]
        [InlineData(LightState.Unknown, LightState.RedYellow, false)]
        
        [InlineData(LightState.Green, LightState.Yellow, false)]
        [InlineData(LightState.Yellow, LightState.Yellow, false)]
        [InlineData(LightState.Red, LightState.Yellow, true)]
        [InlineData(LightState.RedYellow, LightState.Yellow, false)]
        [InlineData(LightState.Unknown, LightState.Yellow, false)]
        
        [InlineData(LightState.Green, LightState.Unknown, false)]
        [InlineData(LightState.Yellow, LightState.Unknown, false)]
        [InlineData(LightState.Red, LightState.Unknown, false)]
        [InlineData(LightState.RedYellow, LightState.Unknown, false)]
        [InlineData(LightState.Unknown, LightState.Unknown, false)]
        public void IsValidConfiguration(LightState firstState, LightState secondState, bool valid)
        {
            Assert.Equal(valid, new CrossingValidator().IsValidConfiguration(firstState, secondState));
        }
    }
}