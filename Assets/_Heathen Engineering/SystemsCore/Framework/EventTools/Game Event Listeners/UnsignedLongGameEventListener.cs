using UnityEngine;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Unsigned Long Game Event Listener")]
    public class UnsignedLongGameEventListener : GameEventListener<ulong>
    {
        public UnsignedLongGameEvent Event;
        public UnityUnsignedLongDataEvent Responce;

        public override IGameEvent<ulong> m_event => Event;

        public override UnityDataEvent<ulong> m_responce => Responce;
    }
}
