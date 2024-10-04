#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Float 2 Game Event Listener")]
    public class Float2GameEventListener : GameEventListener<float2>
    {
        public Float2GameEvent Event;
        public UnityFloat2DataEvent Response;
        public UnityFloat2Event UnityEvent;

        public override IGameEvent<float2> m_event => Event;

        public override UnityDataEvent<float2> m_response => Response;

        public override UnityEvent<float2> m_unityEvent => UnityEvent;
    }
}
#endif