using HeathenEngineering.Scriptable;
using HeathenEngineering.Serializable;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("Heathen/Events/Color Change Event Listener")]
    public class ColorChangeEventListener : ChangeEventListener<SerializableColor>
    {
        public ColorVariable eventSource;

        public UnitySerializableColorEvent valueChanged;
        public UnityColorEvent ColorChanged;

        private void Start()
        {
            valueChanged.AddListener(CascadeCall);
        }

        public override DataVariable<SerializableColor> EventSource
        {
            get
            {
                return eventSource;
            }

            set
            {
                UnregisterListener();
                eventSource = (ColorVariable)value;
                RegisterListener();
            }
        }

        public override UnityEvent<SerializableColor> ValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = (UnitySerializableColorEvent)value;
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

        private void CascadeCall(SerializableColor color)
        {
            ColorChanged.Invoke(color);
        }
    }
}
