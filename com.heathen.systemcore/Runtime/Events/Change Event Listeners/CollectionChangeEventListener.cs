#if HE_SYSCORE
using System.Collections.Generic;

namespace HeathenEngineering.Events
{
    public abstract class CollectionChangeEventListener<T> : ChangeEventListener<List<T>>, ICollectionChangeEventListener<T>
    {
        public abstract ICollectionDataVariable<T> m_collectionvariable { get; }
        public abstract UnityCollectionChangeEvent<T> m_collectionresponce { get; }

        public override void EnableListener()
        {
            base.EnableListener();

            if (m_collectionvariable != null)
                m_collectionvariable.AddListener(this);
        }

        public override void DisableListener()
        {
            base.DisableListener();

            if (m_collectionvariable != null)
                m_collectionvariable.RemoveListener(this);
        }

        public override void OnEventRaised(EventData<List<T>> data)
        {
            base.OnEventRaised(data);

            var nChangeEventData = new CollectionChangeEventData<T>(data.sender, data.value);
            m_collectionresponce.Invoke(nChangeEventData);
        }

        public override void OnEventRaised(EventData data)
        {
            base.OnEventRaised(data);

            var nChangeEventData = new CollectionChangeEventData<T>(data.sender, default);
            m_collectionresponce.Invoke(nChangeEventData);
        }

        public override void OnEventRaised(ChangeEventData<List<T>> data)
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
#endif