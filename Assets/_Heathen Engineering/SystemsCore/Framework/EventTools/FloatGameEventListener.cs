using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering.Events
{
    [AddComponentMenu("Heathen/Events/Float Game Event Listener")]
    public class FloatGameEventListener : MonoBehaviour
    {
        public FloatGameEvent Event;

        public UnityFloatEvent FloatResponce;

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

        public void OnEventRaised(float value)
        {
            FloatResponce.Invoke(value);
        }
    }
}
