#if HE_SYSCORE
using System;

namespace HeathenEngineering.Events
{
    /// <summary>
    /// Standard event data
    /// </summary>
    [Serializable]
    public struct EventData
    {
        /// <summary>
        /// The object that triggered the event
        /// </summary>
        public object sender;

        public EventData(object sender)
        {
            this.sender = sender;
        }
    }

    /// <summary>
    /// Event data with a data type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public struct EventData<T>
    {
        /// <summary>
        /// The obejct that triggered the event
        /// </summary>
        public object sender;
        /// <summary>
        /// The value of the event data
        /// </summary>
        public T value;

        public EventData(object sender, T value)
        {
            this.sender = sender;
            this.value = value;
        }
    }
}
#endif