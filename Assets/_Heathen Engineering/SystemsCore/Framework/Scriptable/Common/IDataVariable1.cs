using HeathenEngineering.Events;

namespace HeathenEngineering.Scriptable
{
    public interface IDataVariable : IGameEvent
    {
        object ObjectValue { get; set; }
    }
}
