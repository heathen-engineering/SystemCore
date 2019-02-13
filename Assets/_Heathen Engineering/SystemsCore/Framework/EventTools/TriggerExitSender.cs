using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [AddComponentMenu("Heathen/Events/Trigger Exit Sender")]
    public class TriggerExitSender : MonoBehaviour
    {
        [Header("Game Event")]
        public TriggerGameEvent PhysicsEvent;

        [Header("Direct Event")]
        public UnityColliderEvent TriggerExited;

        private void OnTriggerExit(Collider other)
        {
            if (PhysicsEvent != null)
                PhysicsEvent.Raise(other);

            TriggerExited.Invoke(other);
        }
    }
}
