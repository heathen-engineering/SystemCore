#if HE_SYSCORE
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Bool Change Event Listener")]
    public class BoolChangeEventListener : ChangeEventListener<bool>
    {
        public BoolVariable eventSource;

        public UnityBoolChangeEvent valueChanged;
        public UnityBoolDataEvent changed;
        public UnityBoolEvent UnityEvent;

        public override IDataVariable<bool> m_variable => eventSource;

        public override UnityChangeEvent<bool> m_changeresponce => valueChanged;

        public override IGameEvent<bool> m_event => eventSource;

        public override UnityDataEvent<bool> m_responce => changed;

        public override UnityEvent<bool> m_unityEvent => UnityEvent;
    }
}
#endif