#if HE_SYSCORE
using System;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Unsigned Long Game Event Listener")]
    public class UnsignedLongGameEventListener : GameEventListener<ulong>
    {
        public UnsignedLongGameEvent Event;
        public UnityUnsignedLongDataEvent Response;
        public UnityUnsignedLongEvent UnityEvent;

        [Obsolete("Please use Response")]
        public UnityUnsignedLongDataEvent Responce => Response;

        public override IGameEvent<ulong> m_event => Event;

        public override UnityDataEvent<ulong> m_response => Response;

        public override UnityEvent<ulong> m_unityEvent => UnityEvent;
    }
}
#endif