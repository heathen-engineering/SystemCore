#if HE_SYSCORE
using System.Collections.Generic;

namespace HeathenEngineering.Events
{
    public interface ICollectionChangeEventListener<T> : IChangeEventListener<List<T>>
    {
        void OnEventRaised(CollectionChangeEventData<T> data);
    }
}
#endif