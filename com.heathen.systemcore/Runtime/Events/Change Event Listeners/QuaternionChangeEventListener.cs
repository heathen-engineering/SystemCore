#if HE_SYSCORE
using HeathenEngineering.Serializable;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Quaternion Change Event Listener")]
    public class QuaternionChangeEventListener : ChangeEventListener<quaternion>
    {
        public QuaternionVariable eventSource;

        public UnitySerializableQuaternionChangeEvent valueChanged;
        public UnitySerializableQuaternionDataEvent changed;
        public UnitySerializableQuaternionEvent UnityEvent;

        public override IDataVariable<quaternion> m_variable => eventSource;

        public override UnityChangeEvent<quaternion> m_changeresponce => valueChanged;

        public override IGameEvent<quaternion> m_event => eventSource;

        public override UnityDataEvent<quaternion> m_responce => changed;

        public override UnityEvent<quaternion> m_unityEvent => UnityEvent;
    }
}
#endif