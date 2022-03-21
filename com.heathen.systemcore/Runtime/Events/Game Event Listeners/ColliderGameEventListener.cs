#if HE_SYSCORE
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Collider Game Event Listener")]
    public class ColliderGameEventListener : GameEventListener<Collider>
    {
        public ColliderGameEvent Event;
        public UnityColliderDataEvent Responce;
        public UnityColliderEvent UnityEvent;

        public override IGameEvent<Collider> m_event => Event;

        public override UnityDataEvent<Collider> m_responce => Responce;

        public override UnityEvent<Collider> m_unityEvent => UnityEvent;
    }
}
#endif