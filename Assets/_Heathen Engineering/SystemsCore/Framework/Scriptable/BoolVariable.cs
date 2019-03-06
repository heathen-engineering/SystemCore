using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "Variables/Bool")]
    public class BoolVariable : DataVariable<bool>
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public bool Value;
        [HideInInspector]
        public List<ChangeEventListener<bool>> Listeners = new List<ChangeEventListener<bool>>();

        public override bool DataValue
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
                if (value.GetType() == typeof(bool))
                    SetValue((bool)value);
            }
        }

        public override void SetValue(bool value)
        {
            if (Value != value)
            {
                Value = value;
                Raise();
            }
        }

        public void SetValue(string value)
        {
            bool v;
            if (bool.TryParse(value, out v))
            {
                if (Value != v)
                {
                    Value = v;
                    Raise();
                }
            }
        }

        public override void SetValue(DataVariable<bool> value)
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

        public override void AddListener(ChangeEventListener<bool> listener)
        {
            Listeners.Add(listener);
        }

        public override void RemoveListener(ChangeEventListener<bool> listener)
        {
            Listeners.Remove(listener);
        }

        public void ToggleValue()
        {
            DataValue = !Value;
        }
    }
}
