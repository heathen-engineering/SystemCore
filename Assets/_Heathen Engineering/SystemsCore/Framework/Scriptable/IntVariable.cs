using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "Variables/Int")]
    public class IntVariable : DataVariable<int>
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public int Value;
        [HideInInspector]
        public List<ChangeEventListener<int>> Listeners = new List<ChangeEventListener<int>>();

        public override int DataValue
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
                if (value.GetType() == typeof(int))
                    SetValue((int)value);
            }
        }

        public override void SetValue(int value)
        {
            if (Value != value)
            {
                Value = value;
                Raise();
            }
        }

        public void SetValue(string value)
        {
            int v;
            if (int.TryParse(value, out v))
            {
                if (Value != v)
                {
                    Value = v;
                    Raise();
                }
            }
        }

        public override void SetValue(DataVariable<int> value)
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

        public override void AddListener(ChangeEventListener<int> listener)
        {
            Listeners.Add(listener);
        }

        public override void RemoveListener(ChangeEventListener<int> listener)
        {
            Listeners.Remove(listener);
        }

        public void Incrament()
        {
            DataValue = Value + 1;
        }

        public void Decrament()
        {
            DataValue = Value - 1;
        }
    }
}
