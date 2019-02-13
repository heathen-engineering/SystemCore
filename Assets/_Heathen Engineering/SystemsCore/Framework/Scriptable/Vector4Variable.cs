using HeathenEngineering.Serializable;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "Variables/Vector4")]
    public class Vector4Variable : DataVariable<SerializableVector4>
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public SerializableVector4 Value;
        [HideInInspector]
        public List<ChangeEventListener<SerializableVector4>> Listeners = new List<ChangeEventListener<SerializableVector4>>();

        public override SerializableVector4 DataValue
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
                if (value.GetType() == typeof(SerializableVector4))
                    SetValue((SerializableVector4)value);
                else if (value.GetType() == typeof(Vector4))
                    SetValue((Vector4)value);
            }
        }

        public override void SetValue(SerializableVector4 value)
        {
            if (Value.x != value.x
                || Value.y != value.y
                || Value.z != value.z
                || Value.w != value.w)
            {
                Value = value;
                Raise();
            }
        }

        public override void SetValue(DataVariable<SerializableVector4> value)
        {
            if (Value.x != value.DataValue.x
                || Value.y != value.DataValue.y
                || Value.z != value.DataValue.z
                || Value.w != value.DataValue.w)
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

        public override void AddListener(ChangeEventListener<SerializableVector4> listener)
        {
            Listeners.Add(listener);
        }

        public override void RemoveListener(ChangeEventListener<SerializableVector4> listener)
        {
            Listeners.Remove(listener);
        }
    }
}
