using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "Events/Double Game Event")]
    public class DoubleGameEvent : GameEvent
    {
        public List<DoubleGameEventListener> doubleListeners = new List<DoubleGameEventListener>();
        public List<UnityAction<double>> doubleActions = new List<UnityAction<double>>();

        public void Raise(double value)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                if (listeners[i] != null)
                    listeners[i].OnEventRaised();
            }

            for (int i = doubleListeners.Count - 1; i >= 0; i--)
            {
                if (doubleListeners[i] != null)
                    doubleListeners[i].OnEventRaised(value);
            }

            for (int i = actions.Count - 1; i >= 0; i--)
            {
                if (actions[i] != null)
                    actions[i].Invoke();
            }

            for (int i = doubleActions.Count - 1; i >= 0; i--)
            {
                if (doubleActions[i] != null)
                    doubleActions[i].Invoke(value);
            }
        }

        public void AddListener(DoubleGameEventListener listener)
        {
            doubleListeners.Add(listener);
        }
        public void RemoveListener(DoubleGameEventListener listener)
        {
            doubleListeners.Remove(listener);
        }
        public void AddListener(UnityAction<double> listener)
        {
            doubleActions.Add(listener);
        }
        public void RemoveListener(UnityAction<double> listener)
        {
            doubleActions.Remove(listener);
        }
    }
}
