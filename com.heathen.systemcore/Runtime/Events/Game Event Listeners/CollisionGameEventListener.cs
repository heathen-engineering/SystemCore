#if HE_SYSCORE
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Collision Game Event Listener")]
    public class CollisionGameEventListener : GameEventListener<Collision>
    {
        public CollisionGameEvent Event;
        public UnityCollisionDataEvent Responce;
        public UnityCollisionEvent UnityEvent;

        public override IGameEvent<Collision> m_event => Event;

        public override UnityDataEvent<Collision> m_responce => Responce;

        public override UnityEvent<Collision> m_unityEvent => UnityEvent;
    }
}
#endif