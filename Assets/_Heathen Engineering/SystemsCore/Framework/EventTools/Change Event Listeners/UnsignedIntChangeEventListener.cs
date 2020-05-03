using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Unsigned Int Change Event Listener")]
    public class UnsignedIntChangeEventListener : ChangeEventListener<uint>
    {
        public UnsignedIntVariable eventSource;

        public UnityUnsignedIntChangeEvent valueChanged;
        public UnityUnsignedIntDataEvent changed;

        public override DataVariable<uint> m_variable => eventSource;

        public override UnityChangeEvent<uint> m_changeresponce => valueChanged;

        public override GameEvent<uint> m_event => eventSource;

        public override UnityDataEvent<uint> m_responce => changed;
    }
}
