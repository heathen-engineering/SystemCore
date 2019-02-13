using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "Events/Float Game Event")]
    public class FloatGameEvent : GameEvent
    {
        public List<FloatGameEventListener> floatListeners;

        public void Raise(float value)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                if (listeners[i] != null)
                    listeners[i].OnEventRaised();
            }

            for (int i = floatListeners.Count - 1; i >= 0; i--)
            {
                if (floatListeners[i] != null)
                    floatListeners[i].OnEventRaised(value);
            }
        }

        public void AddListener(FloatGameEventListener listener)
        {
            floatListeners.Add(listener);
        }
        public void RemoveListener(FloatGameEventListener listener)
        {
            floatListeners.Remove(listener);
        }
    }
}
