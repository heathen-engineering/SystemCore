namespace HeathenEngineering.Events
{
    public interface IGameEventListener<T> : IGameEventListener
    {
        void OnEventRaised(EventData<T> data);
    }
}
