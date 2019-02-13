using HeathenEngineering.Serializable;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Scriptable
{
    [AddComponentMenu("Heathen/Events/Vector4 Change Event Listener")]
    public class Vector4ChangeEventListener : ChangeEventListener<SerializableVector4>
    {
        public Vector4Variable eventSource;

        public UnitySerializableVector4Event valueChanged;
        public UnityVector4Event Vector4Changed;

        public override DataVariable<SerializableVector4> EventSource
        {
            get
            {
                return eventSource;
            }

            set
            {
                UnregisterListener();
                eventSource = (Vector4Variable)value;
                RegisterListener();
            }
        }

        public override UnityEvent<SerializableVector4> ValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = (UnitySerializableVector4Event)value;
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

        private void CascadeCall(SerializableVector4 v2)
        {
            Vector4Changed.Invoke(v2);
        }
    }
}
