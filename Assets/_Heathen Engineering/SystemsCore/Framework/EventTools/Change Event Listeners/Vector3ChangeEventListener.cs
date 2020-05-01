using HeathenEngineering.Scriptable;
using HeathenEngineering.Serializable;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("Heathen/Events/Vector3 Change Event Listener")]
    public class Vector3ChangeEventListener : ChangeEventListener<SerializableVector3>
    {
        public Vector3Variable eventSource;

        public UnitySerializableVector3Event valueChanged;
        public UnityVector3Event Vector3Changed;

        private void Start()
        {
            valueChanged.AddListener(CascadeCall);
        }

        public override DataVariable<SerializableVector3> EventSource
        {
            get
            {
                return eventSource;
            }

            set
            {
                UnregisterListener();
                eventSource = (Vector3Variable)value;
                RegisterListener();
            }
        }

        public override UnityEvent<SerializableVector3> ValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = (UnitySerializableVector3Event)value;
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

        private void CascadeCall(SerializableVector3 v2)
        {
            Vector3Changed.Invoke(v2);
        }
    }
}
