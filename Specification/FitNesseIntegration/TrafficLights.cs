using System;
using fit;
using TrafficLightsControlSystem;

namespace FitNesseIntegration
{
    public class TrafficLights : ColumnFixture
    {
        public string PreviousState { get; set; }

        public string NextState()
        {
            var previousState = PreviousState.ParseToLightState();
            return previousState.Next().NiceString();
        }
    }
}