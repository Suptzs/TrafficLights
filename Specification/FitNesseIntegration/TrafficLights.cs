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

    public class FirstLightSwitchingCrossingController : ColumnFixture
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
            SwitchFirstLight();
        }

        private void SwitchFirstLight()
        {
            if (!IsValidLightStateConfiguration())
            {
                WarningConfiguration();
                return;
            }

            _firstLight = _firstLight.Next();
        }

        private void WarningConfiguration()
        {
            _firstLight = LightState.Unknown;
            _secondLight = LightState.Unknown;
        }

        private bool IsValidLightStateConfiguration()
        {
            return _secondLight == LightState.Red && _firstLight != LightState.Unknown;
        }
    }
}