using HeathenEngineering.Scriptable;
using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Vector2Int Change Event Listener")]
    public class Vector2IntChangeEventListener : ChangeEventListener<SerializableVector2Int>
    {
        public Vector2IntVariable eventSource;

        public UnitySerializableVector2IntChangeEvent valueChanged;
        public UnitySerializableVector2IntDataEvent changed;

        public override IDataVariable<SerializableVector2Int> m_variable => eventSource;

        public override UnityChangeEvent<SerializableVector2Int> m_changeresponce => valueChanged;

        public override IGameEvent<SerializableVector2Int> m_event => eventSource;

        public override UnityDataEvent<SerializableVector2Int> m_responce => changed;
    }
}
