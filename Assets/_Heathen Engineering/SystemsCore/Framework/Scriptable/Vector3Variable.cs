using HeathenEngineering.Events;
using HeathenEngineering.Serializable;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "Variables/Vector3")]
    public class Vector3Variable : DataVariable<SerializableVector3>
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        [SerializeField]
        private SerializableVector3 value;
        [HideInInspector]
        public List<ChangeEventListener<SerializableVector3>> Listeners = new List<ChangeEventListener<SerializableVector3>>();

        public override SerializableVector3 Value
        {
            get
            {
                return this.value;
            }

            set
            {
                SetValue(value);
            }
        }

        public override object ObjectValue
        {
            get
            {
                return this.value;
            }

            set
            {
                if (value.GetType() == typeof(SerializableVector3))
                    SetValue((SerializableVector3)value);
                else if (value.GetType() == typeof(Vector3))
                    SetValue((Vector3)value);
            }
        }

        public override void SetValue(SerializableVector3 value)
        {
            if (this.value.x != value.x
                || this.value.y != value.y
                || this.value.z != value.z)
            {
                this.value = value;
                Raise();
            }
        }

        public override void SetValue(DataVariable<SerializableVector3> value)
        {
            if (this.value.x != value.Value.x
                || this.value.y != value.Value.y
                || this.value.z != value.Value.z)
            {
                this.value = value.Value;
                Raise();
            }
        }

        public override void Raise()
        {
            for (int i = Listeners.Count - 1; i >= 0; i--)
            {
                if (Listeners[i] != null)
                    Listeners[i].OnEventRaised(Value);
            }
        }

        public override void AddListener(ChangeEventListener<SerializableVector3> listener)
        {
            Listeners.Add(listener);
        }

        public override void RemoveListener(ChangeEventListener<SerializableVector3> listener)
        {
            Listeners.Remove(listener);
        }
    }
}
