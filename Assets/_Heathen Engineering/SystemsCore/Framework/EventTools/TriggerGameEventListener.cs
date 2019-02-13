using HeathenEngineering.Serializable;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Scriptable
{
    [AddComponentMenu("Heathen/Events/Trigger Game Event Listener")]
    public class TriggerGameEventListener : MonoBehaviour
    {
        public TriggerGameEvent Event;
        
        public UnityColliderEvent PhysicsResponce;

        private void OnEnable()
        {
            if (Event != null)
                Event.AddListener(this);
        }

        private void OnDisable()
        {
            if (Event != null)
                Event.RemoveListener(this);
        }

        public void OnEventRaised(Collider col)
        {
            PhysicsResponce.Invoke(col);
        }
    }
}
