using HeathenEngineering.Scriptable;
using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Vector3 Change Event Listener")]
    public class Vector3ChangeEventListener : ChangeEventListener<SerializableVector3>
    {
        public Vector3Variable eventSource;

        public UnitySerializableVector3ChangeEvent valueChanged;
        public UnitySerializableVector3DataEvent changed;

        public override DataVariable<SerializableVector3> m_variable => eventSource;

        public override UnityChangeEvent<SerializableVector3> m_changeresponce => valueChanged;

        public override GameEvent<SerializableVector3> m_event => eventSource;

        public override UnityDataEvent<SerializableVector3> m_responce => changed;
    }
}
