#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Vector2Int Change Event Listener")]
    public class Vector2IntChangeEventListener : ChangeEventListener<int2>
    {
        public Vector2IntVariable eventSource;

        public UnitySerializableVector2IntChangeEvent valueChanged;
        public UnitySerializableVector2IntDataEvent changed;
        public UnitySerializableVector2IntEvent UnityEvent;

        public override IDataVariable<int2> m_variable => eventSource;

        public override UnityChangeEvent<int2> m_changeresponce => valueChanged;

        public override IGameEvent<int2> m_event => eventSource;

        public override UnityDataEvent<int2> m_responce => changed;

        public override UnityEvent<int2> m_unityEvent => UnityEvent;
    }
}
#endif