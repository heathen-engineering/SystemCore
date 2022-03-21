#if HE_SYSCORE
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Int Game Event Listener")]
    public class IntGameEventListener : GameEventListener<int>
    {
        public IntGameEvent Event;
        public UnityIntDataEvent Responce;
        public UnityIntEvent UnityEvent;

        public override IGameEvent<int> m_event => Event;

        public override UnityDataEvent<int> m_responce => Responce;

        public override UnityEvent<int> m_unityEvent => UnityEvent;
    }
}
#endif