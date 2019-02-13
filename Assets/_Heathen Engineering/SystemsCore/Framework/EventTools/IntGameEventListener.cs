using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [AddComponentMenu("Heathen/Events/Int Game Event Listener")]
    public class IntGameEventListener : MonoBehaviour
    {
        public IntGameEvent Event;

        public UnityIntEvent IntResponce;

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

        public void OnEventRaised(int value)
        {
            IntResponce.Invoke(value);
        }
    }
}
