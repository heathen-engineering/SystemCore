namespace HeathenEngineering.Events
{
    public interface IGameEventListener
    {
        void EnableListener();
        void DisableListener();
        void OnEventRaised(EventData data);
    }
}
