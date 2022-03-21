#if HE_SYSCORE
using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering.Events
{
    /// <summary>
    /// A componenet behaviour that riases a <see cref="CollisionGameEvent"/> in the OnCollisionExit UnityEvent.
    /// </summary>
    [AddComponentMenu("System Core/Events/Collision Exit Sender")]
    public class CollisionExitSender : MonoBehaviour
    {
        [Header("Game Event")]
        public CollisionGameEvent PhysicsEvent;

        [Header("Direct Event")]
        public UnityCollisionEvent ColliderExited;

        private void OnCollisionExit(Collision collision)
        {
            if (PhysicsEvent != null)
                PhysicsEvent.Raise(collision);

            ColliderExited.Invoke(collision);
        }
    }
}
#endif