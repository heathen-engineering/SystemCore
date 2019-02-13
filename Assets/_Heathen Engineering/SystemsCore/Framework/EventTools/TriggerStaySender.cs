using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [AddComponentMenu("Heathen/Events/Trigger Stay Sender")]
    public class TriggerStaySender : MonoBehaviour
    {
        [Header("Game Event")]
        public TriggerGameEvent PhysicsEvent;

        [Header("Direct Event")]
        public UnityColliderEvent TriggerStayed;

        private void OnTriggerStay(Collider other)
        {
            if (PhysicsEvent != null)
                PhysicsEvent.Raise(other);

            TriggerStayed.Invoke(other);
        }
    }
}
