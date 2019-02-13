using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [AddComponentMenu("Heathen/Events/Double Game Event Listener")]
    public class DoubleGameEventListener : MonoBehaviour
    {
        public DoubleGameEvent Event;

        public UnityDoubleEvent DoubleResponce;

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

        public void OnEventRaised(double value)
        {
            DoubleResponce.Invoke(value);
        }
    }
}
