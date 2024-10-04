#if HE_SYSCORE
using System;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Double Game Event Listener")]
    public class DoubleGameEventListener : GameEventListener<double>
    {
        public DoubleGameEvent Event;
        public UnityDoubleDataEvent Response;
        public UnityDoubleEvent UnityEvent;

        [Obsolete("Please use Response")]
        public UnityDoubleDataEvent Responce => Response;

        public override IGameEvent<double> m_event => Event;

        public override UnityDataEvent<double> m_response => Response;

        public override UnityEvent<double> m_unityEvent => UnityEvent;
    }
}
#endif