#if HE_SYSCORE
using HeathenEngineering.Serializable;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/RectTransform Change Event Listener")]
    public class RectTransformChangeEventListener : ChangeEventListener<SerializableRectTransform>
    {
        public RectTransformVariable eventSource;

        public UnitySerializableRectTransformChangeEvent valueChanged;
        public UnitySerializableRectTransfromDataEvent changed;
        public UnitySerializableRectTransformEvent UnityEvent;

        public override IDataVariable<SerializableRectTransform> m_variable => eventSource;

        public override UnityChangeEvent<SerializableRectTransform> m_changeresponce => valueChanged;

        public override IGameEvent<SerializableRectTransform> m_event => eventSource;

        public override UnityDataEvent<SerializableRectTransform> m_responce => changed;

        public override UnityEvent<SerializableRectTransform> m_unityEvent => UnityEvent;
    }
}
#endif