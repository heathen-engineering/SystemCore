using HeathenEngineering.Scriptable;
using HeathenEngineering.Serializable;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("Heathen/Events/String Change Event Listener")]
    public class StringChangeEventListener : ChangeEventListener<string>
    {
        public StringVariable eventSource;

        public UnityStringEvent responce;

        public override DataVariable<string> EventSource
        {
            get
            {
                return eventSource;
            }

            set
            {
                UnregisterListener();
                eventSource = (StringVariable)value;
                RegisterListener();
            }
        }

        public override UnityEvent<string> ValueChanged
        {
            get
            {
                return responce;
            }
            set
            {
                responce = (UnityStringEvent)value;
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
