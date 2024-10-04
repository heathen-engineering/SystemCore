#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Float 4 Game Event Listener")]
    public class Float4GameEventListener : GameEventListener<float4>
    {
        public Float4GameEvent Event;
        public UnityFloat4DataEvent Response;
        public UnityFloat4Event UnityEvent;

        public override IGameEvent<float4> m_event => Event;

        public override UnityDataEvent<float4> m_response => Response;

        public override UnityEvent<float4> m_unityEvent => UnityEvent;
    }
}
#endif