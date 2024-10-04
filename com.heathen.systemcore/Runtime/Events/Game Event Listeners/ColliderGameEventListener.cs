#if HE_SYSCORE
using System;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("System Core/Events/Collider Game Event Listener")]
    public class ColliderGameEventListener : GameEventListener<Collider>
    {
        public ColliderGameEvent Event;
        public UnityColliderDataEvent Response;
        public UnityColliderEvent UnityEvent;

        [Obsolete("Please use Response")]
        public UnityColliderDataEvent Responce => Response;

        public override IGameEvent<Collider> m_event => Event;

        public override UnityDataEvent<Collider> m_response => Response;

        public override UnityEvent<Collider> m_unityEvent => UnityEvent;
    }
}
#endif