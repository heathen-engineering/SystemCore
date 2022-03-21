#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Vector4 Change Event Listener")]
    public class Vector4ChangeEventListener : ChangeEventListener<float4>
    {
        public Vector4Variable eventSource;

        public UnitySerializableVector4ChangeEvent valueChanged;
        public UnitySerializableVector4DataEvent changed;
        public UnitySerializableVector4Event UnityEvent;

        public override IDataVariable<float4> m_variable => eventSource;

        public override UnityChangeEvent<float4> m_changeresponce => valueChanged;

        public override IGameEvent<float4> m_event => eventSource;

        public override UnityDataEvent<float4> m_responce => changed;

        public override UnityEvent<float4> m_unityEvent => UnityEvent;
    }
}
#endif