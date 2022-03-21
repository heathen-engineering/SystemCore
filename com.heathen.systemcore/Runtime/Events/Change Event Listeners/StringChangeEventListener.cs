#if HE_SYSCORE
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/String Change Event Listener")]
    public class StringChangeEventListener : ChangeEventListener<string>
    {
        public StringVariable eventSource;

        public UnityStringChangeEvent valueChanged;
        public UnityStringDataEvent changed;
        public UnityStringEvent UnityEvent;

        public override IDataVariable<string> m_variable => eventSource;

        public override UnityChangeEvent<string> m_changeresponce => valueChanged;

        public override IGameEvent<string> m_event => eventSource;

        public override UnityDataEvent<string> m_responce => changed;

        public override UnityEvent<string> m_unityEvent => UnityEvent;
    }
}
#endif