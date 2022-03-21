#if HE_SYSCORE
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    /// <summary>
    /// A special game event that deals with the change of data
    /// </summary>
    /// <typeparam name="T">The type of data this event deals with</typeparam>
    public interface IChangeEvent<T> : IGameEvent<T>
    {
        /// <summary>
        /// Raise the change event
        /// </summary>
        /// <param name="sender">The object that triggered the change</param>
        /// <param name="oldValue">The old value that was changed from</param>
        /// <param name="newValue">The new value that was changed to</param>
        void Raise(object sender, T oldValue, T newValue);
        void AddListener(IChangeEventListener<T> listener);
        void RemoveListener(IChangeEventListener<T> listener);
        void AddListener(UnityAction<ChangeEventData<T>> listener);
        void RemoveListener(UnityAction<ChangeEventData<T>> listener);
    }
}
#endif