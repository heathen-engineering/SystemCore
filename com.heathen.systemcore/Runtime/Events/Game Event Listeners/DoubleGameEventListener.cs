#if HE_SYSCORE
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Double Game Event Listener")]
    public class DoubleGameEventListener : GameEventListener<double>
    {
        public DoubleGameEvent Event;
        public UnityDoubleDataEvent Responce;
        public UnityDoubleEvent UnityEvent;

        public override IGameEvent<double> m_event => Event;

        public override UnityDataEvent<double> m_responce => Responce;

        public override UnityEvent<double> m_unityEvent => UnityEvent;
    }
}
#endif