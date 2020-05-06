using HeathenEngineering.Scriptable;
using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Quaternion Change Event Listener")]
    public class QuaternionChangeEventListener : ChangeEventListener<SerializableQuaternion>
    {
        public QuaternionVariable eventSource;

        public UnitySerializableQuaternionChangeEvent valueChanged;
        public UnitySerializableQuaternionDataEvent changed;

        public override IDataVariable<SerializableQuaternion> m_variable => eventSource;

        public override UnityChangeEvent<SerializableQuaternion> m_changeresponce => valueChanged;

        public override IGameEvent<SerializableQuaternion> m_event => eventSource;

        public override UnityDataEvent<SerializableQuaternion> m_responce => changed;
    }
}
