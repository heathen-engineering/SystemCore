using HeathenEngineering.Serializable;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "Variables/Vector2")]
    public class Vector2Variable : DataVariable<SerializableVector2>
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public SerializableVector2 Value;
        [HideInInspector]
        public List<ChangeEventListener<SerializableVector2>> Listeners = new List<ChangeEventListener<SerializableVector2>>();

        public override SerializableVector2 DataValue
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
                if (value.GetType() == typeof(SerializableVector2))
                    SetValue((SerializableVector2)value);
                else if (value.GetType() == typeof(Vector2))
                    SetValue((Vector2)value);
            }
        }

        public override void SetValue(SerializableVector2 value)
        {
            if (Value.x != value.x
                || Value.y != value.y)
            {
                Value = value;
                Raise();
            }
        }

        public override void SetValue(DataVariable<SerializableVector2> value)
        {
            if (Value.x != value.DataValue.x
                || Value.y != value.DataValue.y)
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

        public override void AddListener(ChangeEventListener<SerializableVector2> listener)
        {
            Listeners.Add(listener);
        }

        public override void RemoveListener(ChangeEventListener<SerializableVector2> listener)
        {
            Listeners.Remove(listener);
        }
    }
}
