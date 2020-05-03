using HeathenEngineering.Events;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    /// <summary>
    /// Need all DataVariables to be change events ... should probably be on DatatVariable not DataVariable<T></T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public abstract class DataVariable<T> : ChangeEvent<T>, IDataVariable<T>
    {
        [SerializeField]
        private T m_value;

        public T Value 
        {
            get { return GetValue(); }
            set { SetValue(value); } 
        }

        public object ObjectValue
        {
            get { return GetValue(); }
            set { SetValue(value as DataVariable<T>); }
        }

        public T GetValue()
        {
            return m_value;
        }

        public void SetValue(T value)
        {
            if (!EqualityComparer<T>.Default.Equals(m_value, value))
            {
                T oldvalue = m_value;
                m_value = value;
                Raise(this, oldvalue, m_value);
            }
        }

        public void SetValue(IDataVariable<T> value)
        {
            SetValue(value.Value);
        }
    }
}
