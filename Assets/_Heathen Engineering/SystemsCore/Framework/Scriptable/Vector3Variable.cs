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
        public SerializableVector3 Value;
        [HideInInspector]
        public List<ChangeEventListener<SerializableVector3>> Listeners = new List<ChangeEventListener<SerializableVector3>>();

        public override SerializableVector3 DataValue
        {
            get
            {
                return Value;
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
                return DataValue;
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
            if (Value.x != value.x
                || Value.y != value.y
                || Value.z != value.z)
            {
                Value = value;
                Raise();
            }
        }

        public override void SetValue(DataVariable<SerializableVector3> value)
        {
            if (Value.x != value.DataValue.x
                || Value.y != value.DataValue.y
                || Value.z != value.DataValue.z)
            {
                Value = value.DataValue;
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
