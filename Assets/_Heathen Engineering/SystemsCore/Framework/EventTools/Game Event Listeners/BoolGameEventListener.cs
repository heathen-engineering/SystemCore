using HeathenEngineering.Serializable;
using UnityEngine;

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

        public override GameEvent<bool> m_event => Event;

        public override UnityDataEvent<bool> m_responce => Responce;
    }
}
