using HeathenEngineering.Serializable;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "Variables/Float")]
    public class FloatVariable : DataVariable<float>
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public float Value;
        
        [HideInInspector]
        public List<ChangeEventListener<float>> Listeners = new List<ChangeEventListener<float>>();

        public override float DataValue
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
                if (value.GetType() == typeof(float))
                    SetValue((float)value);
            }
        }

        public override void SetValue(float value)
        {
            if (Value != value)
            {
                Value = value;
                Raise();
            }
        }

        public void SetValue(string value)
        {
            float v;
            if (float.TryParse(value, out v))
            {
                if (Value != v)
                {
                    Value = v;
                    Raise();
                }
            }
        }

        public override void SetValue(DataVariable<float> value)
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

        public override void AddListener(ChangeEventListener<float> listener)
        {
            Listeners.Add(listener);
        }

        public override void RemoveListener(ChangeEventListener<float> listener)
        {
            Listeners.Remove(listener);
        }
    }
}
