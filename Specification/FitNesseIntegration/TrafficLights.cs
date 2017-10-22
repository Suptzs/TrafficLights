using System;
using System.Globalization;
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
        private readonly CrossingValidator _validator = new CrossingValidator();

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
            if (!_validator.IsValidConfiguration(_firstLight, _secondLight))
            {
                WarningConfiguration();
                return;
            }

            _firstLight = _firstLight.Next();
            
            if(!_validator.IsValidConfiguration(_firstLight, _secondLight))
                WarningConfiguration();
        }

        private void WarningConfiguration()
        {
            _firstLight = LightState.Unknown;
            _secondLight = LightState.Unknown;
        }
    }
}