using UnityEngine;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/String Game Event Listener")]
    public class StringGameEventListener : GameEventListener<string>
    {
        public StringGameEvent Event;
        public UnityStringDataEvent Responce;

        public override IGameEvent<string> m_event => Event;

        public override UnityDataEvent<string> m_responce => Responce;
    }
}
