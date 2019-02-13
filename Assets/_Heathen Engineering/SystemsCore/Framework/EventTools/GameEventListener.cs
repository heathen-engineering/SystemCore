using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Scriptable
{
    [AddComponentMenu("Heathen/Events/Game Event Listener")]
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent Event;
        public UnityEvent Responce;

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

        public void OnEventRaised()
        {
            Responce.Invoke();
        }
    }
}
