#if HE_SYSCORE
using System;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Collision Game Event Listener")]
    public class CollisionGameEventListener : GameEventListener<Collision>
    {
        public CollisionGameEvent Event;
        public UnityCollisionDataEvent Response;
        public UnityCollisionEvent UnityEvent;

        [Obsolete("Please use Response")]
        public UnityCollisionDataEvent Responce => Response;

        public override IGameEvent<Collision> m_event => Event;

        public override UnityDataEvent<Collision> m_response => Response;

        public override UnityEvent<Collision> m_unityEvent => UnityEvent;
    }
}
#endif