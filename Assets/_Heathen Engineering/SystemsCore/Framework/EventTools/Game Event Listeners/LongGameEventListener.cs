using UnityEngine;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Long Game Event Listener")]
    public class LongGameEventListener : GameEventListener<long>
    {
        public LongGameEvent Event;
        public UnityLongDataEvent Responce;

        public override IGameEvent<long> m_event => Event;

        public override UnityDataEvent<long> m_responce => Responce;
    }
}
