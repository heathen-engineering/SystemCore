using HeathenEngineering.Scriptable;
using HeathenEngineering.Serializable;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("Heathen/Events/Float Change Event Listener")]
    public class FloatChangeEventListener : ChangeEventListener<float>
    {
        public FloatVariable eventSource;

        public UnityFloatEvent valueChanged;

        public override DataVariable<float> EventSource
        {
            get
            {
                return eventSource;
            }

            set
            {
                UnregisterListener();
                eventSource = (FloatVariable)value;
                RegisterListener();
            }
        }

        public override UnityEvent<float> ValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = (UnityFloatEvent)value;
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
