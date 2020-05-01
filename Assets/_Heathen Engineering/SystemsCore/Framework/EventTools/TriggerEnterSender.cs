using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("Heathen/Events/Trigger Enter Sender")]
    public class TriggerEnterSender : MonoBehaviour
    {
        [Header("Game Event")]
        public TriggerGameEvent PhysicsEvent;

        [Header("Direct Event")]
        public UnityColliderEvent TriggerEntered;

        private void OnTriggerEnter(Collider other)
        {
            if (PhysicsEvent != null)
                PhysicsEvent.Raise(other);

            TriggerEntered.Invoke(other);
        }
    }
}
