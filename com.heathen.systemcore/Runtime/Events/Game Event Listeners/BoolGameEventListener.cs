#if HE_SYSCORE
using HeathenEngineering.Serializable;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    /// <summary>
    /// A component behavior that registers to listen on a specific GameEvent and raises its <see cref="BoolGameEventListener.BoolResponce"/> event when received.
    /// </summary>
    [AddComponentMenu("System Core/Events/Bool Game Event Listener")]
    public class BoolGameEventListener : GameEventListener<bool>
    {
        public BoolGameEvent Event;
        public UnityBoolDataEvent Response;
        public UnityBoolEvent UnityEvent;

        [Obsolete("Please use Response")]
        public UnityBoolDataEvent Responce => Response;

        public override IGameEvent<bool> m_event => Event;

        public override UnityDataEvent<bool> m_response => Response;

        public override UnityEvent<bool> m_unityEvent => UnityEvent;
    }
}
#endif