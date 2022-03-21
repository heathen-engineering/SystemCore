#if HE_SYSCORE
using System;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Game Event Listener")]
    public class GameEventListener : MonoBehaviour, IGameEventListener
    {
        public GameEvent Event;
        public UnityDataEvent Responce;

        private void OnEnable()
        {
            EnableListener();
        }

        private void OnDisable()
        {
            DisableListener();
        }

        public virtual void EnableListener()
        {
            if (Event != null)
                Event.AddListener(this);
        }

        public virtual void DisableListener()
        {
            if (Event != null)
                Event.RemoveListener(this);
        }

        public virtual void OnEventRaised(EventData data)
        {
            Responce.Invoke(data);
        }
    }

    public abstract class GameEventListener<T> : MonoBehaviour, IGameEventListener<T>
    {
        public BoolReference raiseOnBind = new BoolReference(true);
        public abstract IGameEvent<T> m_event { get; }
        public abstract UnityDataEvent<T> m_responce { get; }
        public abstract UnityEvent<T> m_unityEvent { get; }

        private void OnEnable()
        {
            EnableListener();
        }

        private void OnDisable()
        {
            DisableListener();
        }

        public virtual void EnableListener()
        {
            if (m_event != null)
                m_event.AddListener(this);
        }

        public virtual void DisableListener()
        {
            if (m_event != null)
                m_event.RemoveListener(this);
        }

        public virtual void OnEventRaised(EventData<T> data)
        {
            m_responce.Invoke(data);
            m_unityEvent.Invoke(data.value);
        }

        public virtual void OnEventRaised(EventData data)
        {
            m_responce.Invoke(new EventData<T>(data.sender, default));
            m_unityEvent.Invoke(default);
        }
    }
}
#endif