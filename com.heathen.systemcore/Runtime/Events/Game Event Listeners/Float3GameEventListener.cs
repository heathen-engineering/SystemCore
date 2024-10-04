#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Float 3 Game Event Listener")]
    public class Float3GameEventListener : GameEventListener<float3>
    {
        public Float3GameEvent Event;
        public UnityFloat3DataEvent Response;
        public UnityFloat3Event UnityEvent;

        public override IGameEvent<float3> m_event => Event;

        public override UnityDataEvent<float3> m_response => Response;

        public override UnityEvent<float3> m_unityEvent => UnityEvent;
    }
}
#endif