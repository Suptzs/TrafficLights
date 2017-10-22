namespace TrafficLightsControlSystem
{
    public class CrossingValidator
    {
        public bool IsValidConfiguration(LightState firstState, LightState secondState)
        {
            if (firstState == LightState.Unknown) return false;
            if (secondState == LightState.Unknown) return false;
            
            if (firstState == LightState.Red) return true;
            if (secondState == LightState.Red) return true;

            return false;
        }
    }
}