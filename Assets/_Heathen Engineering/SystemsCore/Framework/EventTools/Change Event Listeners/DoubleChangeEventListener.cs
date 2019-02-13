using HeathenEngineering.Serializable;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Scriptable
{
    [AddComponentMenu("Heathen/Events/Double Change Event Listener")]
    public class DoubleChangeEventListener : ChangeEventListener<double>
    {
        public DoubleVariable eventSource;

        public UnityDoubleEvent valueChanged;

        public override DataVariable<double> EventSource
        {
            get
            {
                return eventSource;
            }

            set
            {
                UnregisterListener();
                eventSource = (DoubleVariable)value;
                RegisterListener();
            }
        }

        public override UnityEvent<double> ValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = (UnityDoubleEvent)value;
            }
        }

        private void OnEnable()
        {
            RegisterListener();
        }

        private void OnDisable()
        {
            UnregisterListener();
        }
    }
}
