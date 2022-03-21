#if HE_SYSCORE
using System;
using System.Collections.Generic;

namespace HeathenEngineering.Events
{
    [Serializable]
    public struct CollectionChangeEventData<T>
    {
        /// <summary>
        /// The object that triggered the event
        /// </summary>
        public object sender;
        public List<T> newState;

        public CollectionChangeEventData(object sender, List<T> newState)
        {
            this.sender = sender;
            this.newState = newState;
        }
    }
}
#endif