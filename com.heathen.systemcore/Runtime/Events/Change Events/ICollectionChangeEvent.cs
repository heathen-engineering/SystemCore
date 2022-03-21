#if HE_SYSCORE
using System.Collections.Generic;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    public interface ICollectionChangeEvent<T> : IChangeEvent<List<T>>
    {
        void AddListener(ICollectionChangeEventListener<T> listener);
        void RemoveListener(ICollectionChangeEventListener<T> listener);
        void AddListener(UnityAction<CollectionChangeEventData<T>> listener);
        void RemoveListener(UnityAction<CollectionChangeEventData<T>> listener);
    }
}
#endif