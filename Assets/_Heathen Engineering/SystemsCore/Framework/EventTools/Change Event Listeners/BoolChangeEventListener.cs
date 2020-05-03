using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Bool Change Event Listener")]
    public class BoolChangeEventListener : ChangeEventListener<bool>
    {
        public BoolVariable eventSource;

        public UnityBoolChangeEvent valueChanged;
        public UnityBoolDataEvent changed;

        public override DataVariable<bool> m_variable => eventSource;

        public override UnityChangeEvent<bool> m_changeresponce => valueChanged;

        public override GameEvent<bool> m_event => eventSource;

        public override UnityDataEvent<bool> m_responce => changed;
    }
}
