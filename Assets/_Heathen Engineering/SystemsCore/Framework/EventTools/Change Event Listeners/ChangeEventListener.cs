using HeathenEngineering.Scriptable;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    public abstract class ChangeEventListener<T> : GameEventListener<T>, IChangeEventListener<T>
    {
        public abstract DataVariable<T> m_variable { get; }
        public abstract UnityChangeEvent<T> m_changeresponce { get; }

        new public virtual void EnableListener()
        {
            base.EnableListener();

            if (m_variable != null)
                m_variable.AddListener(this);
        }

        new public virtual void DisableListener()
        {
            base.DisableListener();

            if (m_variable != null)
                m_variable.RemoveListener(this);
        }

        new public virtual void OnEventRaised(EventData<T> data)
        {
            base.OnEventRaised(data);

            var nChangeEventData = new ChangeEventData<T>() { sender = data.sender, oldValue = default, newValue = data.value };
            m_changeresponce.Invoke(nChangeEventData);
        }

        new public virtual void OnEventRaised(EventData data)
        {
            base.OnEventRaised(data);

            var nChangeEventData = new ChangeEventData<T>() { sender = data.sender, oldValue = default, newValue = default };
            m_changeresponce.Invoke(nChangeEventData);
        }

        public virtual void OnEventRaised(ChangeEventData<T> data)
        {
            m_responce.Invoke(new EventData<T>(data.sender, data.newValue));
            m_changeresponce.Invoke(data);
        }
    }
}
