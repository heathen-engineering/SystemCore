#if HE_SYSCORE
using System;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Int Game Event Listener")]
    public class IntGameEventListener : GameEventListener<int>
    {
        public IntGameEvent Event;
        public UnityIntDataEvent Response;
        public UnityIntEvent UnityEvent;

        [Obsolete("Please use Response")]
        public UnityIntDataEvent Responce => Response;

        public override IGameEvent<int> m_event => Event;

        public override UnityDataEvent<int> m_response => Response;

        public override UnityEvent<int> m_unityEvent => UnityEvent;
    }
}
#endif