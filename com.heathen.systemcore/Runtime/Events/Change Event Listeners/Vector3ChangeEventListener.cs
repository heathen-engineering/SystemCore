#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Vector3 Change Event Listener")]
    public class Vector3ChangeEventListener : ChangeEventListener<float3>
    {
        public Vector3Variable eventSource;

        public UnitySerializableVector3ChangeEvent valueChanged;
        public UnitySerializableVector3DataEvent changed;
        public UnitySerializableVector3Event UnityEvent;

        public override IDataVariable<float3> m_variable => eventSource;

        public override UnityChangeEvent<float3> m_changeresponce => valueChanged;

        public override IGameEvent<float3> m_event => eventSource;

        public override UnityDataEvent<float3> m_responce => changed;

        public override UnityEvent<float3> m_unityEvent => UnityEvent;
    }
}
#endif