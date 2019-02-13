using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "Events/Int Game Event")]
    public class IntGameEvent : GameEvent
    {
        public List<IntGameEventListener> intListeners;

        public void Raise(int value)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                if (listeners[i] != null)
                    listeners[i].OnEventRaised();
            }

            for (int i = intListeners.Count - 1; i >= 0; i--)
            {
                if (intListeners[i] != null)
                    intListeners[i].OnEventRaised(value);
            }
        }

        public void AddListener(IntGameEventListener listener)
        {
            intListeners.Add(listener);
        }
        public void RemoveListener(IntGameEventListener listener)
        {
            intListeners.Remove(listener);
        }
    }
}
