using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "Events/Trigger Game Event")]
    public class TriggerGameEvent : GameEvent
    {
        public List<TriggerGameEventListener> triggerListeners;

        public void Raise(Collider collider)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                if (listeners[i] != null)
                    listeners[i].OnEventRaised();
            }

            for (int i = triggerListeners.Count - 1; i >= 0; i--)
            {
                if (triggerListeners[i] != null)
                    triggerListeners[i].OnEventRaised(collider);
            }
        }

        public void AddListener(TriggerGameEventListener listener)
        {
            triggerListeners.Add(listener);
        }
        public void RemoveListener(TriggerGameEventListener listener)
        {
            triggerListeners.Remove(listener);
        }
    }
}
