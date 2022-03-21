#if HE_SYSCORE
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    /// <summary>
    /// Basic interface for a game event
    /// </summary>
    public interface IGameEvent
    {
        void Invoke();
        void Raise();
        void Invoke(object sender);
        /// <summary>
        /// Raise the game event
        /// </summary>
        /// <param name="sender">The object that wishes to raise the event</param>
        void Raise(object sender);
        void AddListener(IGameEventListener listener);
        void RemoveListener(IGameEventListener listener);
        void AddListener(UnityAction<EventData> listener);
        void RemoveListener(UnityAction<EventData> listener);
    }

    /// <summary>
    /// Game event that works with a given data type
    /// </summary>
    /// <typeparam name="T">The type of data to raise in the event</typeparam>
    public interface IGameEvent<T> : IGameEvent
    {
        void Invoke(T value);
        void Raise(T value);
        void Invoke(object sender, T value);
        /// <summary>
        /// Raise the game event
        /// </summary>
        /// <param name="sender">The object that wishes to raise the event</param>
        /// <param name="value">The data the object wishes to raise with the event</param>
        void Raise(object sender, T value);
        void AddListener(IGameEventListener<T> listener);
        void RemoveListener(IGameEventListener<T> listener);
        void AddListener(UnityAction<EventData<T>> listener);
        void RemoveListener(UnityAction<EventData<T>> listener);
    }
}
#endif