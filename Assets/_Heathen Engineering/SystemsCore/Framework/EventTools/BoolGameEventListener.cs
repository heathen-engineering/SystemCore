using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering.Events
{
    /// <summary>
    /// A componenet behaviour that registers to listen on a specific GameEvent and raises its <see cref="BoolGameEventListener.BoolResponce"/> event when recieved.
    /// </summary>
    [AddComponentMenu("Heathen/Events/Bool Game Event Listener")]
    public class BoolGameEventListener : MonoBehaviour
    {
        /// <summary>
        /// The <see cref="BoolGameEvent"/> to listen for
        /// </summary>
        public BoolGameEvent Event;

        /// <summary>
        /// Occures when the <see cref="Event"/> is raised
        /// </summary>
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
