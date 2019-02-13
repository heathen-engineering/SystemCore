using HeathenEngineering.Serializable;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Scriptable
{
    [AddComponentMenu("Heathen/Events/Vector2 Change Event Listener")]
    public class Vector2ChangeEventListener : ChangeEventListener<SerializableVector2>
    {
        public Vector2Variable eventSource;

        public UnitySerializableVector2Event valueChanged;
        public UnityVector2Event Vector2Changed;

        private void Start()
        {
            valueChanged.AddListener(CascadeCall);
        }

        public override DataVariable<SerializableVector2> EventSource
        {
            get
            {
                return eventSource;
            }

            set
            {
                UnregisterListener();
                eventSource = (Vector2Variable)value;
                RegisterListener();
            }
        }

        public override UnityEvent<SerializableVector2> ValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = (UnitySerializableVector2Event)value;
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

        private void CascadeCall(SerializableVector2 v2)
        {
            Vector2Changed.Invoke(v2);
        }
    }
}
