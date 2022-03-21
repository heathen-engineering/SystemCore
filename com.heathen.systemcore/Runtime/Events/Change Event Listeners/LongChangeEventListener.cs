#if HE_SYSCORE
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Long Change Event Listener")]
    public class LongChangeEventListener : ChangeEventListener<long>
    {
        public LongVariable eventSource;

        public UnityLongChangeEvent valueChanged;
        public UnityLongDataEvent changed;
        public UnityLongEvent UnityEvent;

        public override IDataVariable<long> m_variable => eventSource;

        public override UnityChangeEvent<long> m_changeresponce => valueChanged;

        public override IGameEvent<long> m_event => eventSource;

        public override UnityDataEvent<long> m_responce => changed;

        public override UnityEvent<long> m_unityEvent => UnityEvent;
    }
}
#endif