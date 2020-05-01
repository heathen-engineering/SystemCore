using HeathenEngineering.Scriptable;
using HeathenEngineering.Serializable;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("Heathen/Events/Vector2Int Change Event Listener")]
    public class Vector2IntChangeEventListener : ChangeEventListener<SerializableVector2Int>
    {
        public Vector2IntVariable eventSource;

        public UnitySerializableVector2IntEvent valueChanged;
        public UnityVector2IntEvent Vector2IntChanged;

        private void Start()
        {
            valueChanged.AddListener(CascadeCall);
        }

        public override DataVariable<SerializableVector2Int> EventSource
        {
            get
            {
                return eventSource;
            }

            set
            {
                UnregisterListener();
                eventSource = (Vector2IntVariable)value;
                RegisterListener();
            }
        }

        public override UnityEvent<SerializableVector2Int> ValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = (UnitySerializableVector2IntEvent)value;
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

        private void CascadeCall(SerializableVector2Int v2)
        {
            Vector2IntChanged.Invoke(v2);
        }
    }
}
