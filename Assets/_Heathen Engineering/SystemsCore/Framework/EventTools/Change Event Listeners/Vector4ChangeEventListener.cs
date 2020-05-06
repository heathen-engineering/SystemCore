using HeathenEngineering.Scriptable;
using HeathenEngineering.Serializable;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Vector4 Change Event Listener")]
    public class Vector4ChangeEventListener : ChangeEventListener<SerializableVector4>
    {
        public Vector4Variable eventSource;

        public UnitySerializableVector4ChangeEvent valueChanged;
        public UnitySerializableVector4DataEvent changed;
        public UnitySerializableVector4Event UnityEvent;

        public override IDataVariable<SerializableVector4> m_variable => eventSource;

        public override UnityChangeEvent<SerializableVector4> m_changeresponce => valueChanged;

        public override IGameEvent<SerializableVector4> m_event => eventSource;

        public override UnityDataEvent<SerializableVector4> m_responce => changed;

        public override UnityEvent<SerializableVector4> m_unityEvent => UnityEvent;
    }
}
