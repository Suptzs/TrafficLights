using System;

namespace TrafficLightsControlSystem
{
    public static class LightStateExtensionMethods
    {
        public static LightState Next(this LightState currentState)
        {
            switch (currentState)
            {
                case LightState.Red:
                    return LightState.RedYellow;
                case LightState.RedYellow:
                    return LightState.Green;
                case LightState.Green:
                    return LightState.Yellow;
                case LightState.Yellow:
                    return LightState.Red;
                case LightState.Unknown:
                    return LightState.Unknown;
                default:
                    return LightState.Unknown;
            }
        }
        
        public static string NiceString(this LightState state)
        {
            switch (state)
            {
                case LightState.RedYellow:
                    return "Red, Yellow";
                case LightState.Unknown:
                    return "Yellow blink";
                default:
                    return state.ToString();
            }
        }

        /// <summary>
        /// Parse a color to a traffic light state
        /// </summary>
        /// <param name="color">Description of traffic light color</param>
        /// <returns>LightState</returns>
        public static LightState ParseToLightState(this string color)
        {
            var formatted = color.Replace(" ", "").Replace(",", "");

            var canParse = Enum.TryParse(formatted, true, out LightState previous);

            if (!canParse)
                previous = LightState.Unknown;
            
            return previous;
        }
    }
}