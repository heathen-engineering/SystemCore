#if HE_SYSCORE
using System;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Unsigned Int Game Event Listener")]
    public class UnsignedIntGameEventListener : GameEventListener<uint>
    {
        public UnsignedIntGameEvent Event;
        public UnityUnsignedIntDataEvent Response;
        public UnityUnsignedIntEvent UnityEvent;

        [Obsolete("Please use Response")]
        public UnityUnsignedIntDataEvent Responce => Response;

        public override IGameEvent<uint> m_event => Event;

        public override UnityDataEvent<uint> m_response => Response;

        public override UnityEvent<uint> m_unityEvent => UnityEvent;
    }
}
#endif