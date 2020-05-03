using UnityEngine;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Double Game Event Listener")]
    public class DoubleGameEventListener : GameEventListener<double>
    {
        public DoubleGameEvent Event;
        public UnityDoubleDataEvent Responce;

        public override GameEvent<double> m_event => Event;

        public override UnityDataEvent<double> m_responce => Responce;
    }
}
