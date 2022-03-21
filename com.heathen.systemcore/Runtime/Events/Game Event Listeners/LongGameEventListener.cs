#if HE_SYSCORE
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Long Game Event Listener")]
    public class LongGameEventListener : GameEventListener<long>
    {
        public LongGameEvent Event;
        public UnityLongDataEvent Responce;
        public UnityLongEvent UnityEvent;

        public override IGameEvent<long> m_event => Event;

        public override UnityDataEvent<long> m_responce => Responce;

        public override UnityEvent<long> m_unityEvent => UnityEvent;
    }
}
#endif