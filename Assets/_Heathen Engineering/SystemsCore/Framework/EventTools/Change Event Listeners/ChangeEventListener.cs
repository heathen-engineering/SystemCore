using HeathenEngineering.Scriptable;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    public abstract class ChangeEventListener<T> : MonoBehaviour
    {
        public BoolReference raiseOnBind = new BoolReference(true);
        public abstract DataVariable<T> EventSource { get; set; }
        
        public abstract UnityEvent<T> ValueChanged { get; set; }

        public virtual void RegisterListener()
        {
            if (EventSource != null)
                EventSource.AddListener(this);
            if (raiseOnBind)
                ValueChanged.Invoke(EventSource.Value);
        }

        public virtual void UnregisterListener()
        {
            if (EventSource != null)
                EventSource.RemoveListener(this);
        }

        /// <summary>
        /// Thread safe execute the value changed event
        /// </summary>
        /// <param name="value"></param>
        public virtual void OnEventRaised(T value)
        {
            ValueChanged.Invoke(value);
        }
    }
}
