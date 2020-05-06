using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Unsigned Long Change Event Listener")]
    public class UnsignedLongChangeEventListener : ChangeEventListener<ulong>
    {
        public UnsignedLongVariable eventSource;

        public UnityUnsignedLongChangeEvent valueChanged;
        public UnityUnsignedLongDataEvent changed;

        public override IDataVariable<ulong> m_variable => eventSource;

        public override UnityChangeEvent<ulong> m_changeresponce => valueChanged;

        public override IGameEvent<ulong> m_event => eventSource;

        public override UnityDataEvent<ulong> m_responce => changed;
    }
}
