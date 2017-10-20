using System;
using TrafficLightsControlSystem;
using Xunit;

namespace TrafficLightsTests
{
    public class LightStateTransitionTest
    {
        [Theory]
        [InlineData(LightState.Red, LightState.RedYellow)]
        [InlineData(LightState.RedYellow, LightState.Green)]
        [InlineData(LightState.Green, LightState.Yellow)]
        [InlineData(LightState.Yellow, LightState.Red)]
        [InlineData(LightState.Unknown, LightState.Unknown)]
        public void TestStateChange(LightState current, LightState next)
        {
            Assert.Equal(next, current.Next());
        }
    }
}