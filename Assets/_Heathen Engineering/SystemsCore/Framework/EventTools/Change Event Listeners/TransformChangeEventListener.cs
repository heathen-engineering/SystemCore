using HeathenEngineering.Scriptable;
using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Transform Change Event Listener")]
    public class TransformChangeEventListener : ChangeEventListener<SerializableTransform>
    {
        public TransformVariable eventSource;

        public UnitySerializableTransformChangeEvent valueChanged;
        public UnitySerializableTransfromDataEvent changed;

        public override IDataVariable<SerializableTransform> m_variable => eventSource;

        public override UnityChangeEvent<SerializableTransform> m_changeresponce => valueChanged;

        public override IGameEvent<SerializableTransform> m_event => eventSource;

        public override UnityDataEvent<SerializableTransform> m_responce => changed;
    }
}
