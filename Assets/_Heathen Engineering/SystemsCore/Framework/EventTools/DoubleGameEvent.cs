using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "Events/Double Game Event")]
    public class DoubleGameEvent : GameEvent
    {
        public List<DoubleGameEventListener> boolListeners;

        public void Raise(double value)
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

        public void AddListener(DoubleGameEventListener listener)
        {
            boolListeners.Add(listener);
        }
        public void RemoveListener(DoubleGameEventListener listener)
        {
            boolListeners.Remove(listener);
        }
    }
}
