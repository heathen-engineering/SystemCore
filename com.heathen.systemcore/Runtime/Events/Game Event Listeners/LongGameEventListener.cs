#if HE_SYSCORE
using System;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Long Game Event Listener")]
    public class LongGameEventListener : GameEventListener<long>
    {
        public LongGameEvent Event;
        public UnityLongDataEvent Response;
        public UnityLongEvent UnityEvent;

        [Obsolete("Please use Response")]
        public UnityLongDataEvent Responce => Response;

        public override IGameEvent<long> m_event => Event;

        public override UnityDataEvent<long> m_response => Response;

        public override UnityEvent<long> m_unityEvent => UnityEvent;
    }
}
#endif