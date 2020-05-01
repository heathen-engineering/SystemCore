using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("Heathen/Events/String Game Event Listener")]
    public class StringGameEventListener : MonoBehaviour
    {
        public StringGameEvent Event;

        public UnityStringEvent StringResponce;

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

        public void OnEventRaised(string value)
        {
            StringResponce.Invoke(value);
        }
    }
}
