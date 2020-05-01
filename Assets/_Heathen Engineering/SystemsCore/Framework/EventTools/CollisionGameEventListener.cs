using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("Heathen/Events/Collision Game Event Listener")]
    public class CollisionGameEventListener : MonoBehaviour
    {
        public CollisionGameEvent Event;

        public UnityCollisionEvent PhysicsResponce;

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

        public void OnEventRaised(Collision col)
        {
            PhysicsResponce.Invoke(col);
        }
    }
}
