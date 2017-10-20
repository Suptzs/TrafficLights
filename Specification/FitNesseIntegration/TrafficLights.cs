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

    public class FirstLightSwitchingCrossingControler : ColumnFixture
    {
        private LightState _firstLight;
        private LightState _secondLight;

        public string FirstLight
        {
            get => _firstLight.NiceString();
            set => _firstLight = value.ParseToLightState();
        }

        public string SecondLight
        {
            get => _secondLight.NiceString();
            set => _secondLight = value.ParseToLightState();
        }

        public override void Execute()
        {
            _firstLight = _firstLight.Next();
        }
    }
}