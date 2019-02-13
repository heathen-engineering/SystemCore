using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [AddComponentMenu("Heathen/Events/Collision Exit Sender")]
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
