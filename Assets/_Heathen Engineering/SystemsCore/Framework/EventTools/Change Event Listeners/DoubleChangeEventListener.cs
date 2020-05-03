using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Double Change Event Listener")]
    public class DoubleChangeEventListener : ChangeEventListener<double>
    {
        public DoubleVariable eventSource;

        public UnityDoubleChangeEvent valueChanged;
        public UnityDoubleDataEvent changed;

        public override DataVariable<double> m_variable => eventSource;

        public override UnityChangeEvent<double> m_changeresponce => valueChanged;

        public override GameEvent<double> m_event => eventSource;

        public override UnityDataEvent<double> m_responce => changed;
    }
}
