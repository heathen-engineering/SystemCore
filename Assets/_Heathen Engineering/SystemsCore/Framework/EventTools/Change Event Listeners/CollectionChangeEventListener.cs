using HeathenEngineering.Scriptable;
using System.Collections.Generic;

namespace HeathenEngineering.Events
{
    public abstract class CollectionChangeEventListener<T> : ChangeEventListener<List<T>>, ICollectionChangeEventListener<T>
    {
        public abstract CollectionDataVariable<T> m_collectionvariable { get; }
        public abstract UnityCollectionChangeEvent<T> m_collectionresponce { get; }

        new public virtual void EnableListener()
        {
            base.EnableListener();

            if (m_collectionvariable != null)
                m_collectionvariable.AddListener(this);
        }

        new public virtual void DisableListener()
        {
            base.DisableListener();

            if (m_collectionvariable != null)
                m_collectionvariable.RemoveListener(this);
        }

        new public virtual void OnEventRaised(EventData<List<T>> data)
        {
            base.OnEventRaised(data);

            var nChangeEventData = new CollectionChangeEventData<T>(data.sender, data.value);
            m_collectionresponce.Invoke(nChangeEventData);
        }

        new public virtual void OnEventRaised(EventData data)
        {
            base.OnEventRaised(data);

            var nChangeEventData = new CollectionChangeEventData<T>(data.sender, default);
            m_collectionresponce.Invoke(nChangeEventData);
        }

        new public virtual void OnEventRaised(ChangeEventData<List<T>> data)
        {
            base.OnEventRaised(data);

            var nChangeEventData = new CollectionChangeEventData<T>(data.sender, data.newValue);
            m_collectionresponce.Invoke(nChangeEventData);
        }

        public virtual void OnEventRaised(CollectionChangeEventData<T> data)
        {
            m_responce.Invoke(new EventData<List<T>>(data.sender, data.newState));
            m_changeresponce.Invoke(new ChangeEventData<List<T>>(data.sender, default, data.newState));
            m_collectionresponce.Invoke(data);
        }
    }
}
