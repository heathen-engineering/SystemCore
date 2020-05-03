using UnityEngine;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Unsigned Int Game Event Listener")]
    public class UnsignedIntGameEventListener : GameEventListener<uint>
    {
        public UnsignedIntGameEvent Event;
        public UnityUnsignedIntDataEvent Responce;

        public override GameEvent<uint> m_event => Event;

        public override UnityDataEvent<uint> m_responce => Responce;
    }
}
