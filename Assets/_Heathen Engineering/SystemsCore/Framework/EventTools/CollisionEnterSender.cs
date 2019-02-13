using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [AddComponentMenu("Heathen/Events/Collision Enter Sender")]
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
