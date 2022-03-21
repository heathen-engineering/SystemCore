#if HE_SYSCORE
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    public interface IGameEventListener
    {
        void EnableListener();
        void DisableListener();
        void OnEventRaised(EventData data);
    }

    public interface IGameEventListener<T> : IGameEventListener
    {
        UnityEvent<T> m_unityEvent { get; }

        void OnEventRaised(EventData<T> data);
    }
}
#endif