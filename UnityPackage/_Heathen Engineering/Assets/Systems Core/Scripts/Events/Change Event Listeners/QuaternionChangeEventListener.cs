using HeathenEngineering.Scriptable;
using HeathenEngineering.Serializable;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Quaternion Change Event Listener")]
    public class QuaternionChangeEventListener : ChangeEventListener<SerializableQuaternion>
    {
        public QuaternionVariable eventSource;

        public UnitySerializableQuaternionChangeEvent valueChanged;
        public UnitySerializableQuaternionDataEvent changed;
        public UnitySerializableQuaternionEvent UnityEvent;

        public override IDataVariable<SerializableQuaternion> m_variable => eventSource;

        public override UnityChangeEvent<SerializableQuaternion> m_changeresponce => valueChanged;

        public override IGameEvent<SerializableQuaternion> m_event => eventSource;

        public override UnityDataEvent<SerializableQuaternion> m_responce => changed;

        public override UnityEvent<SerializableQuaternion> m_unityEvent => UnityEvent;
    }
}
