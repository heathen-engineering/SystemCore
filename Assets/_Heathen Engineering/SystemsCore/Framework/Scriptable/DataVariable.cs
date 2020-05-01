using HeathenEngineering.Events;
using System;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public abstract class DataVariable<T> : DataVariable
    {
        public abstract T Value { get; set; }

        public abstract void SetValue(T value);

        public abstract void SetValue(DataVariable<T> value);

        public abstract void Raise();

        public abstract void AddListener(ChangeEventListener<T> listener);

        public abstract void RemoveListener(ChangeEventListener<T> listener);
    }

    [Serializable]
    public abstract class DataVariable : ScriptableObject
    {
        public abstract object ObjectValue { get; set; }
    }   
}
