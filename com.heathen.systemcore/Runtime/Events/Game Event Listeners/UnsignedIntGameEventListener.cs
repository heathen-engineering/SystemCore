#if HE_SYSCORE
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Unsigned Int Game Event Listener")]
    public class UnsignedIntGameEventListener : GameEventListener<uint>
    {
        public UnsignedIntGameEvent Event;
        public UnityUnsignedIntDataEvent Responce;
        public UnityUnsignedIntEvent UnityEvent;

        public override IGameEvent<uint> m_event => Event;

        public override UnityDataEvent<uint> m_responce => Responce;

        public override UnityEvent<uint> m_unityEvent => UnityEvent;
    }
}
#endif