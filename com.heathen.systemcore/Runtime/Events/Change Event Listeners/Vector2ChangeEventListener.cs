#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Vector2 Change Event Listener")]
    public class Vector2ChangeEventListener : ChangeEventListener<float2>
    {
        public Vector2Variable eventSource;

        public UnitySerializableVector2ChangeEvent valueChanged;
        public UnitySerializableVector2DataEvent changed;
        public UnitySerializableVector2Event UnityEvent;

        public override IDataVariable<float2> m_variable => eventSource;

        public override UnityChangeEvent<float2> m_changeresponce => valueChanged;

        public override IGameEvent<float2> m_event => eventSource;

        public override UnityDataEvent<float2> m_responce => changed;

        public override UnityEvent<float2> m_unityEvent => UnityEvent;
    }
}
#endif