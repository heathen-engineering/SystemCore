#if HE_SYSCORE
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    /// <summary>
    /// <para>Create an event as an object in your project folder.</para>
    /// <para>This represents a general game event ... that is an event defined in your project folder.</para>
    /// </summary>
    [CreateAssetMenu(menuName = "System Core/Events/Simple Events/Void")]
    public class GameEvent : ScriptableObject, IGameEvent
    {
        internal const string dd01 = "Empty UnityActions are being depricated in favor of UnityAction<object> where the sender of the event will be passed in as well. \nPlease use AddListener(UnityAction<object>) instead.";

#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif

        [HideInInspector]
        public List<IGameEventListener> listeners = new List<IGameEventListener>();
        [HideInInspector]
        public List<UnityAction<EventData>> senderActions = new List<UnityAction<EventData>>();
        
        public virtual void Invoke(object sender)
        {
            Raise(sender);
        }

        public virtual void Raise(object sender)
        {
            EventData nData = new EventData() { sender = sender };

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
        }

        public void AddListener(IGameEventListener listener)
        {
            listeners.Add(listener);
        }

        public void AddListener(UnityAction<EventData> listener)
        {
            senderActions.Add(listener);
        }
        
        public void RemoveListener(IGameEventListener listener)
        {
            listeners.Remove(listener);
        }

        public void RemoveListener(UnityAction<EventData> listener)
        {
            senderActions.Remove(listener);
        }

        public void Invoke()
        {
            Raise(this);
        }

        public void Raise()
        {
            Raise(this);
        }
    }

    /// <summary>
    /// Used as the base class for all custom GameEvents
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GameEvent<T> : GameEvent, IGameEvent<T>
    {
        [HideInInspector]
        public List<IGameEventListener<T>> typeListeners = new List<IGameEventListener<T>>();
        [HideInInspector]
        public List<UnityAction<EventData<T>>> typeSenderActions = new List<UnityAction<EventData<T>>>();

        public void AddListener(IGameEventListener<T> listener)
        {
            typeListeners.Add(listener);
        }

        public void AddListener(UnityAction<EventData<T>> listener)
        {
            typeSenderActions.Add(listener);
        }

        public virtual void RaiseSimple(T value)
        {
            Raise(this, value);
        }

        public virtual void InvokeSimple(T value)
        {
            Raise(this, value);
        }

        public override void Raise(object sender)
        {
            Raise(sender, default);
        }

        public virtual void Invoke(object sender, T value)
        {
            Raise(sender, value);
        }

        public virtual void Raise(object sender, T value)
        {
            EventData nData = new EventData() { sender = sender };
            EventData<T> typeData = new EventData<T>(sender, value);

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
        }

        public void RemoveListener(IGameEventListener<T> listener)
        {
            typeListeners.Remove(listener);
        }

        public void RemoveListener(UnityAction<EventData<T>> listener)
        {
            typeSenderActions.Remove(listener);
        }

        public virtual void Invoke(T value)
        {
            Raise(this, value);
        }

        public virtual void Raise(T value)
        {
            Raise(this, value);
        }
    }
}
#endif