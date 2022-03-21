#if HE_SYSCORE
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Unsigned Long Change Event Listener")]
    public class UnsignedLongChangeEventListener : ChangeEventListener<ulong>
    {
        public UnsignedLongVariable eventSource;

        public UnityUnsignedLongChangeEvent valueChanged;
        public UnityUnsignedLongDataEvent changed;
        public UnityUnsignedLongEvent UnityEvent;

        public override IDataVariable<ulong> m_variable => eventSource;

        public override UnityChangeEvent<ulong> m_changeresponce => valueChanged;

        public override IGameEvent<ulong> m_event => eventSource;

        public override UnityDataEvent<ulong> m_responce => changed;

        public override UnityEvent<ulong> m_unityEvent => UnityEvent;
    }
}
#endif