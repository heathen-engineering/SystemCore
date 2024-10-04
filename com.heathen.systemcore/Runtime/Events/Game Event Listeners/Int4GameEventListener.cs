#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Int 4 Game Event Listener")]
    public class Int4GameEventListener : GameEventListener<int4>
    {
        public Int4GameEvent Event;
        public UnityInt4DataEvent Response;
        public UnityInt4Event UnityEvent;

        public override IGameEvent<int4> m_event => Event;

        public override UnityDataEvent<int4> m_response => Response;

        public override UnityEvent<int4> m_unityEvent => UnityEvent;
    }
}
#endif