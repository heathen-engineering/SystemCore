using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "Events/Bool Game Event")]
    public class BoolGameEvent : GameEvent
    {
        public List<BoolGameEventListener> boolListeners;

        public void Raise(bool value)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                if (listeners[i] != null)
                    listeners[i].OnEventRaised();
            }

            for (int i = boolListeners.Count - 1; i >= 0; i--)
            {
                if (boolListeners[i] != null)
                    boolListeners[i].OnEventRaised(value);
            }
        }

        public void AddListener(BoolGameEventListener listener)
        {
            boolListeners.Add(listener);
        }
        public void RemoveListener(BoolGameEventListener listener)
        {
            boolListeners.Remove(listener);
        }
    }
}
