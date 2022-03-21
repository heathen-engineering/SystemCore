#if HE_SYSCORE
using HeathenEngineering.Serializable;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    /// <summary>
    /// A componenet behaviour that registers to listen on a specific GameEvent and raises its <see cref="BoolGameEventListener.BoolResponce"/> event when recieved.
    /// </summary>
    [AddComponentMenu("System Core/Events/Bool Game Event Listener")]
    public class BoolGameEventListener : GameEventListener<bool>
    {
        public BoolGameEvent Event;
        public UnityBoolDataEvent Responce;
        public UnityBoolEvent UnityEvent;

        public override IGameEvent<bool> m_event => Event;

        public override UnityDataEvent<bool> m_responce => Responce;

        public override UnityEvent<bool> m_unityEvent => UnityEvent;
    }
}
#endif