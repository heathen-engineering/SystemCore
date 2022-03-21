#if HE_SYSCORE
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    public abstract class ChangeEvent<T> : GameEvent<T>, IChangeEvent<T>
    {
        [HideInInspector]
        public List<IChangeEventListener<T>> typeChangeListeners = new List<IChangeEventListener<T>>();
        [HideInInspector]
        public List<UnityAction<ChangeEventData<T>>> typeChangeSenderActions = new List<UnityAction<ChangeEventData<T>>>();

        public void AddListener(IChangeEventListener<T> listener)
        {
            typeChangeListeners.Add(listener);
        }

        public void AddListener(UnityAction<ChangeEventData<T>> listener)
        {
            typeChangeSenderActions.Add(listener);
        }

        public override void Raise(object sender)
        {
            Raise(sender, default, default);
        }

        public override void Raise(object sender, T value)
        {
            Raise(sender, default, value);
        }

        public void Raise(object sender, T oldValue, T newValue)
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

        public void RemoveListener(IChangeEventListener<T> listener)
        {
            typeChangeListeners.Remove(listener);
        }

        public void RemoveListener(UnityAction<ChangeEventData<T>> listener)
        {
            typeChangeSenderActions.Remove(listener);
        }
    }
}
#endif