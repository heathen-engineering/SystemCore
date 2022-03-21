#if HE_SYSCORE
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Float Change Event Listener")]
    public class FloatChangeEventListener : ChangeEventListener<float>
    {
        public FloatVariable eventSource;

        public UnityFloatChangeEvent valueChanged;
        public UnityFloatDataEvent changed;
        public UnityFloatEvent UnityEvent;

        public override IDataVariable<float> m_variable => eventSource;

        public override UnityChangeEvent<float> m_changeresponce => valueChanged;

        public override IGameEvent<float> m_event => eventSource;

        public override UnityDataEvent<float> m_responce => changed;

        public override UnityEvent<float> m_unityEvent => UnityEvent;
    }
}
#endif