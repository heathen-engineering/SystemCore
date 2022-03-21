#if HE_SYSCORE
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Int Change Event Listener")]
    public class IntChangeEventListener : ChangeEventListener<int>
    {
        public IntVariable eventSource;

        public UnityIntChangeEvent valueChanged;
        public UnityIntDataEvent changed;
        public UnityIntEvent UnityEvent;

        public override IDataVariable<int> m_variable => eventSource;

        public override UnityChangeEvent<int> m_changeresponce => valueChanged;

        public override IGameEvent<int> m_event => eventSource;

        public override UnityDataEvent<int> m_responce => changed;

        public override UnityEvent<int> m_unityEvent => UnityEvent;
    }
}
#endif