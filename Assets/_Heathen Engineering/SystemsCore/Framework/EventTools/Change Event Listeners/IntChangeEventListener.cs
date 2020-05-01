using HeathenEngineering.Scriptable;
using HeathenEngineering.Serializable;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("Heathen/Events/Int Change Event Listener")]
    public class IntChangeEventListener : ChangeEventListener<int>
    {
        public IntVariable eventSource;

        public UnityIntEvent valueChanged;

        public override DataVariable<int> EventSource
        {
            get
            {
                return eventSource;
            }

            set
            {
                UnregisterListener();
                eventSource = (IntVariable)value;
                RegisterListener();
            }
        }

        public override UnityEvent<int> ValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = (UnityIntEvent)value;
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
