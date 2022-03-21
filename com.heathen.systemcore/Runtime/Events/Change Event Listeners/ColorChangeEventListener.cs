#if HE_SYSCORE
using HeathenEngineering.Serializable;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Color Change Event Listener")]
    public class ColorChangeEventListener : ChangeEventListener<float4>
    {
        public ColorVariable eventSource;

        public UnitySerializableColorChangeEvent valueChanged;
        public UnitySerializableColorDataEvent changed;
        public UnitySerializableColorEvent UnityEvent;

        public override IDataVariable<float4> m_variable => eventSource;

        public override UnityChangeEvent<float4> m_changeresponce => valueChanged;

        public override IGameEvent<float4> m_event => eventSource;

        public override UnityDataEvent<float4> m_responce => changed;

        public override UnityEvent<float4> m_unityEvent => UnityEvent;
    }
}
#endif