#if HE_SYSCORE
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Double Change Event Listener")]
    public class DoubleChangeEventListener : ChangeEventListener<double>
    {
        public DoubleVariable eventSource;

        public UnityDoubleChangeEvent valueChanged;
        public UnityDoubleDataEvent changed;
        public UnityDoubleEvent UnityEvent;

        public override IDataVariable<double> m_variable => eventSource;

        public override UnityChangeEvent<double> m_changeresponce => valueChanged;

        public override IGameEvent<double> m_event => eventSource;

        public override UnityDataEvent<double> m_responce => changed;

        public override UnityEvent<double> m_unityEvent => UnityEvent;
    }
}
#endif