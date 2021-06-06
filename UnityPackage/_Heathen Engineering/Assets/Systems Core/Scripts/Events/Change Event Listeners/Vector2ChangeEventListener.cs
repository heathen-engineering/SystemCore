using HeathenEngineering.Scriptable;
using HeathenEngineering.Serializable;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Vector2 Change Event Listener")]
    public class Vector2ChangeEventListener : ChangeEventListener<SerializableVector2>
    {
        public Vector2Variable eventSource;

        public UnitySerializableVector2ChangeEvent valueChanged;
        public UnitySerializableVector2DataEvent changed;
        public UnitySerializableVector2Event UnityEvent;

        public override IDataVariable<SerializableVector2> m_variable => eventSource;

        public override UnityChangeEvent<SerializableVector2> m_changeresponce => valueChanged;

        public override IGameEvent<SerializableVector2> m_event => eventSource;

        public override UnityDataEvent<SerializableVector2> m_responce => changed;

        public override UnityEvent<SerializableVector2> m_unityEvent => UnityEvent;
    }
}
