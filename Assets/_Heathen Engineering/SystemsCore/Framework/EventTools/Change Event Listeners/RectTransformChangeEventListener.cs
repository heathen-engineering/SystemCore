using HeathenEngineering.Scriptable;
using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/RectTransform Change Event Listener")]
    public class RectTransformChangeEventListener : ChangeEventListener<SerializableRectTransform>
    {
        public RectTransformVariable eventSource;

        public UnitySerializableRectTransformChangeEvent valueChanged;
        public UnitySerializableRectTransfromDataEvent changed;

        public override IDataVariable<SerializableRectTransform> m_variable => eventSource;

        public override UnityChangeEvent<SerializableRectTransform> m_changeresponce => valueChanged;

        public override IGameEvent<SerializableRectTransform> m_event => eventSource;

        public override UnityDataEvent<SerializableRectTransform> m_responce => changed;
    }
}
