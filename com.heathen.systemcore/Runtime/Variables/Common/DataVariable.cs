#if HE_SYSCORE
using HeathenEngineering.Events;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering
{
    /// <summary>
    /// Need all DataVariables to be change events ... should probably be on DatatVariable not DataVariable<T></T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public abstract class DataVariable<T> : DataVariable, IChangeEvent<T>, IDataVariable<T>
    {
        [SerializeField]
        internal T m_value;

        [HideInInspector]
        public List<IGameEventListener<T>> typeListeners = new List<IGameEventListener<T>>();
        [HideInInspector]
        public List<UnityAction<EventData<T>>> typeSenderActions = new List<UnityAction<EventData<T>>>();
        [HideInInspector]
        public List<IChangeEventListener<T>> typeChangeListeners = new List<IChangeEventListener<T>>();
        [HideInInspector]
        public List<UnityAction<ChangeEventData<T>>> typeChangeSenderActions = new List<UnityAction<ChangeEventData<T>>>();

        public T Value 
        {
            get { return GetValue(); }
            set { SetValue(value); } 
        }

        public override object ObjectValue
        {
            get { return GetValue(); }
            set { SetValue((T)value); }
        }

        public void AddListener(IGameEventListener<T> listener)
        {
            typeListeners.Add(listener);
        }

        public void AddListener(UnityAction<EventData<T>> listener)
        {
            typeSenderActions.Add(listener);
        }

        public void AddListener(IChangeEventListener<T> listener)
        {
            typeChangeListeners.Add(listener);
        }

        public void AddListener(UnityAction<ChangeEventData<T>> listener)
        {
            typeChangeSenderActions.Add(listener);
        }

        public T GetValue()
        {
            return m_value;
        }

        public override void Raise(object sender)
        {
            Raise(sender, default, default);
        }

        public virtual void Raise(object sender, T value) 
        {
            Raise(sender, default, value);
        }

        public virtual void Raise(object sender, T oldValue, T newValue)
        {
            EventData nData = new EventData() { sender = sender };
            EventData<T> typeData = new EventData<T>(sender, newValue);
            ChangeEventData<T> changeData = new ChangeEventData<T>(sender, oldValue, newValue);

            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                if (listeners[i] != null)
                    listeners[i].OnEventRaised(nData);
            }
            for (int i = senderActions.Count - 1; i >= 0; i--)
            {
                if (senderActions[i] != null)
                    senderActions[i].Invoke(nData);
            }

            for (int i = typeListeners.Count - 1; i >= 0; i--)
            {
                if (typeListeners[i] != null)
                    typeListeners[i].OnEventRaised(typeData);
            }
            for (int i = typeSenderActions.Count - 1; i >= 0; i--)
            {
                if (typeSenderActions[i] != null)
                    typeSenderActions[i].Invoke(typeData);
            }

            for (int i = typeChangeListeners.Count - 1; i >= 0; i--)
            {
                if (typeChangeListeners[i] != null)
                    typeChangeListeners[i].OnEventRaised(changeData);
            }
            for (int i = typeChangeSenderActions.Count - 1; i >= 0; i--)
            {
                if (typeChangeSenderActions[i] != null)
                    typeChangeSenderActions[i].Invoke(changeData);
            }
        }

        public void RemoveListener(IGameEventListener<T> listener)
        {
            typeListeners.Remove(listener);
        }

        public void RemoveListener(UnityAction<EventData<T>> listener)
        {
            typeSenderActions.Remove(listener);
        }

        public void RemoveListener(IChangeEventListener<T> listener)
        {
            typeChangeListeners.Remove(listener);
        }

        public void RemoveListener(UnityAction<ChangeEventData<T>> listener)
        {
            typeChangeSenderActions.Remove(listener);
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

        public void Invoke(T value)
        {
            Raise(this, value);
        }

        public void Raise(T value)
        {
            Raise(this, value);
        }

        public void Invoke(object sender, T value)
        {
            Raise(sender, value);
        }
    }

    public abstract class DataVariable : GameEvent, IDataVariable
    {
        public abstract object ObjectValue { get; set; }
    }
}
#endif