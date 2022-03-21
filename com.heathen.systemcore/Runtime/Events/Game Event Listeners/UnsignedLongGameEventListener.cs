#if HE_SYSCORE
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Unsigned Long Game Event Listener")]
    public class UnsignedLongGameEventListener : GameEventListener<ulong>
    {
        public UnsignedLongGameEvent Event;
        public UnityUnsignedLongDataEvent Responce;
        public UnityUnsignedLongEvent UnityEvent;

        public override IGameEvent<ulong> m_event => Event;

        public override UnityDataEvent<ulong> m_responce => Responce;

        public override UnityEvent<ulong> m_unityEvent => UnityEvent;
    }
}
#endif