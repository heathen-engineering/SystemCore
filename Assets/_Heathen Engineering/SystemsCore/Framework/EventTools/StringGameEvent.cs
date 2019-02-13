using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "Events/String Game Event")]
    public class StringGameEvent : GameEvent
    {
        public List<StringGameEventListener> boolListeners;
        
        public void Raise(string value)
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

        public void AddListener(StringGameEventListener listener)
        {
            boolListeners.Add(listener);
        }
        public void RemoveListener(StringGameEventListener listener)
        {
            boolListeners.Remove(listener);
        }
    }
}
