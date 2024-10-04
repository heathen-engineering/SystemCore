#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Int 3 Game Event Listener")]
    public class Int3GameEventListener : GameEventListener<int3>
    {
        public Int3GameEvent Event;
        public UnityInt3DataEvent Response;
        public UnityInt3Event UnityEvent;

        public override IGameEvent<int3> m_event => Event;

        public override UnityDataEvent<int3> m_response => Response;

        public override UnityEvent<int3> m_unityEvent => UnityEvent;
    }
}
#endif