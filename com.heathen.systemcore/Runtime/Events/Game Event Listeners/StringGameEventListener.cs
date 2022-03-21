#if HE_SYSCORE
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/String Game Event Listener")]
    public class StringGameEventListener : GameEventListener<string>
    {
        public StringGameEvent Event;
        public UnityStringDataEvent Responce;
        public UnityStringEvent UnityEvent;

        public override IGameEvent<string> m_event => Event;

        public override UnityDataEvent<string> m_responce => Responce;

        public override UnityEvent<string> m_unityEvent => UnityEvent;
    }
}
#endif