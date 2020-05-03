using HeathenEngineering.Scriptable;
using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Vector4 Change Event Listener")]
    public class Vector4ChangeEventListener : ChangeEventListener<SerializableVector4>
    {
        public Vector4Variable eventSource;

        public UnitySerializableVector4ChangeEvent valueChanged;
        public UnitySerializableVector4DataEvent changed;

        public override DataVariable<SerializableVector4> m_variable => eventSource;

        public override UnityChangeEvent<SerializableVector4> m_changeresponce => valueChanged;

        public override GameEvent<SerializableVector4> m_event => eventSource;

        public override UnityDataEvent<SerializableVector4> m_responce => changed;
    }
}
