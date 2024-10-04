#if HE_SYSCORE
using System;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/String Game Event Listener")]
    public class StringGameEventListener : GameEventListener<string>
    {
        public StringGameEvent Event;
        public UnityStringDataEvent Response;
        public UnityStringEvent UnityEvent;

        [Obsolete("Please use Response")]
        public UnityStringDataEvent Responce => Response;

        public override IGameEvent<string> m_event => Event;

        public override UnityDataEvent<string> m_response => Response;

        public override UnityEvent<string> m_unityEvent => UnityEvent;
    }
}
#endif