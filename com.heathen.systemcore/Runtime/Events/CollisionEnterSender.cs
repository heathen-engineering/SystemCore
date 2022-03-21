#if HE_SYSCORE
using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering.Events
{
    /// <summary>
    /// A componenet behaviour that riases a <see cref="CollisionGameEvent"/> in the OnCollisionEnter UnityEvent.
    /// </summary>
    [AddComponentMenu("System Core/Events/Collision Enter Sender")]
    public class CollisionEnterSender : MonoBehaviour
    {
        [Header("Game Event")]
        public CollisionGameEvent PhysicsEvent;

        [Header("Direct Event")]
        public UnityCollisionEvent ColliderEntered;
        
        private void OnCollisionEnter(Collision collision)
        {
            if (PhysicsEvent != null)
                PhysicsEvent.Raise(collision);

            ColliderEntered.Invoke(collision);
        }
    }
}
#endif