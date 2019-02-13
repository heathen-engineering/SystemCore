using HeathenEngineering.Serializable;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "Variables/Vector2Int")]
    public class Vector2IntVariable : DataVariable<SerializableVector2Int>
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public SerializableVector2Int Value;
        [HideInInspector]
        public List<ChangeEventListener<SerializableVector2Int>> Listeners = new List<ChangeEventListener<SerializableVector2Int>>();

        public override SerializableVector2Int DataValue
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
                if (value.GetType() == typeof(SerializableVector2Int))
                    SetValue((SerializableVector2Int)value);
                else if (value.GetType() == typeof(Vector2Int))
                    SetValue((Vector2Int)value);
            }
        }

        public override void SetValue(SerializableVector2Int value)
        {
            if (Value.x != value.x
                || Value.y != value.y)
            {
                Value = value;
                Raise();
            }
        }

        public override void SetValue(DataVariable<SerializableVector2Int> value)
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

        public override void AddListener(ChangeEventListener<SerializableVector2Int> listener)
        {
            Listeners.Add(listener);
        }

        public override void RemoveListener(ChangeEventListener<SerializableVector2Int> listener)
        {
            Listeners.Remove(listener);
        }
    }
}
