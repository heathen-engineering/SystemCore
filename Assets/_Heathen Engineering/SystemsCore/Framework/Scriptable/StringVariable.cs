using HeathenEngineering.Serializable;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "Variables/String")]
    public class StringVariable : DataVariable<string>
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        [Multiline]
        public string Value;
        [HideInInspector]
        public List<ChangeEventListener<string>> Listeners = new List<ChangeEventListener<string>>();

        public override string DataValue
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
                return Value;
            }

            set
            {
                if (value.GetType() == typeof(string))
                    SetValue((string)value);
                else
                    SetValue(value.ToString());
            }
        }

        public override void SetValue(string value)
        {
            if (Value != value)
            {
                Value = value;
                Raise();
            }
        }

        public override void SetValue(DataVariable<string> value)
        {
            if (Value != value.DataValue)
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

        public override void AddListener(ChangeEventListener<string> listener)
        {
            Listeners.Add(listener);
        }

        public override void RemoveListener(ChangeEventListener<string> listener)
        {
            Listeners.Remove(listener);
        }
    }
}
