#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Int 2 Game Event Listener")]
    public class Int2GameEventListener : GameEventListener<int2>
    {
        public Int2GameEvent Event;
        public UnityInt2DataEvent Response;
        public UnityInt2Event UnityEvent;

        public override IGameEvent<int2> m_event => Event;

        public override UnityDataEvent<int2> m_response => Response;

        public override UnityEvent<int2> m_unityEvent => UnityEvent;
    }
}
#endif