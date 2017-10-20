using TrafficLightsControlSystem;
using Xunit;

namespace TrafficLightsTests
{
    public class LightStateParsingTest
    {
        [Theory]
        [InlineData("Red", LightState.Red)]
        [InlineData("red", LightState.Red)]
        [InlineData("Yellow", LightState.Yellow)]
        [InlineData("Red Yellow", LightState.RedYellow)]
        [InlineData("Red, Yellow", LightState.RedYellow)]
        [InlineData("Green", LightState.Green)]
        [InlineData("Invalid", LightState.Unknown)]
        public void GivenColorString_ParseToLightStateEnum(string color, LightState expected)
        {
            Assert.Equal(expected, color.ParseToLightState());
        }
    }
}