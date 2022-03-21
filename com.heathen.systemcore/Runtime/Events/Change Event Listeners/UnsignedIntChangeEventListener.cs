#if HE_SYSCORE
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Unsigned Int Change Event Listener")]
    public class UnsignedIntChangeEventListener : ChangeEventListener<uint>
    {
        public UnsignedIntVariable eventSource;

        public UnityUnsignedIntChangeEvent valueChanged;
        public UnityUnsignedIntDataEvent changed;
        public UnityUnsignedIntEvent UnityEvent;

        public override IDataVariable<uint> m_variable => eventSource;

        public override UnityChangeEvent<uint> m_changeresponce => valueChanged;

        public override IGameEvent<uint> m_event => eventSource;

        public override UnityDataEvent<uint> m_responce => changed;

        public override UnityEvent<uint> m_unityEvent => UnityEvent;
    }
}
#endif