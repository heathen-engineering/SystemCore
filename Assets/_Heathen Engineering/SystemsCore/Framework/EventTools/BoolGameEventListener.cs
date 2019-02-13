using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [AddComponentMenu("Heathen/Events/Bool Game Event Listener")]
    public class BoolGameEventListener : MonoBehaviour
    {
        public BoolGameEvent Event;

        public UnityBoolEvent BoolResponce;

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

        public void OnEventRaised(bool value)
        {
            BoolResponce.Invoke(value);
        }
    }
}
