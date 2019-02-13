using HeathenEngineering.Serializable;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Scriptable
{
    [AddComponentMenu("Heathen/Events/Bool Change Event Listener")]
    public class BoolChangeEventListener : ChangeEventListener<bool>
    {
        public BoolVariable eventSource;

        public UnityBoolEvent valueChanged;

        public override DataVariable<bool> EventSource
        {
            get
            {
                return eventSource;
            }

            set
            {
                UnregisterListener();
                eventSource = (BoolVariable)value;
                RegisterListener();
            }
        }

        public override UnityEvent<bool> ValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = (UnityBoolEvent)value;
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
