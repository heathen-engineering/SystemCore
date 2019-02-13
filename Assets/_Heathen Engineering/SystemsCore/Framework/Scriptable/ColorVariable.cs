using HeathenEngineering.Serializable;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "Variables/Color")]
    public class ColorVariable : DataVariable<SerializableColor>
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public SerializableColor Value;
        [HideInInspector]
        public List<ChangeEventListener<SerializableColor>> Listeners = new List<ChangeEventListener<SerializableColor>>();

        public override SerializableColor DataValue
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
                if (value.GetType() == typeof(SerializableColor))
                    SetValue((SerializableColor)value);
                else if (value.GetType() == typeof(Color))
                    SetValue((Color)value);
            }
        }

        public override void SetValue(SerializableColor value)
        {
            if (value.r != Value.r
                || value.g != Value.g
                || value.b != Value.b
                || value.a != Value.a)
            {
                Value = value;
                Raise();
            }
        }

        public override void SetValue(DataVariable<SerializableColor> value)
        {
            if (value.DataValue.r != Value.r
                || value.DataValue.g != Value.g
                || value.DataValue.b != Value.b
                || value.DataValue.a != Value.a)
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

        public override void AddListener(ChangeEventListener<SerializableColor> listener)
        {
            Listeners.Add(listener);
        }

        public override void RemoveListener(ChangeEventListener<SerializableColor> listener)
        {
            Listeners.Remove(listener);
        }
    }
}
