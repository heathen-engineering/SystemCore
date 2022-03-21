#if HE_SYSCORE
using System;

namespace HeathenEngineering.Events
{
    /// <summary>
    /// A special event data variant for use with ChangeEvents
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public struct ChangeEventData<T>
    {
        /// <summary>
        /// The object that triggered the event
        /// </summary>
        public object sender;
        /// <summary>
        /// The old value before the change
        /// </summary>
        public T oldValue;
        /// <summary>
        /// The new value e.g. after the chagne
        /// </summary>
        public T newValue;

        public ChangeEventData(object sender, T oldValue, T newValue)
        {
            this.sender = sender;
            this.oldValue = oldValue;
            this.newValue = newValue;
        }
    }
}
#endif