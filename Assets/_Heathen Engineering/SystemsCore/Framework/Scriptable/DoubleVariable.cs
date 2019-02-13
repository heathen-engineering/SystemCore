using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "Variables/Double")]
    public class DoubleVariable : DataVariable<double>
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public double Value;
        [HideInInspector]
        public List<ChangeEventListener<double>> Listeners = new List<ChangeEventListener<double>>();

        public override double DataValue
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
                if (value.GetType() == typeof(double))
                    SetValue((double)value);
            }
        }

        public override void SetValue(double value)
        {
            if (value != Value)
            {
                Value = value;
                Raise();
            }
        }

        public void SetValue(string value)
        {
            double v;
            if (double.TryParse(value, out v))
            {
                if (Value != v)
                {
                    Value = v;
                    Raise();
                }
            }
        }

        public override void SetValue(DataVariable<double> value)
        {
            if (value.DataValue != Value)
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

        public override void AddListener(ChangeEventListener<double> listener)
        {
            Listeners.Add(listener);
        }

        public override void RemoveListener(ChangeEventListener<double> listener)
        {
            Listeners.Remove(listener);
        }
    }
}
