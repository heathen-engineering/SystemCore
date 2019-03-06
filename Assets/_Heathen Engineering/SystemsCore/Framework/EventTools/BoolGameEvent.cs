using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "Events/Bool Game Event")]
    public class BoolGameEvent : GameEvent
    {
        public List<BoolGameEventListener> boolListeners = new List<BoolGameEventListener>();
        public List<UnityAction<bool>> boolActions = new List<UnityAction<bool>>();

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

            for (int i = actions.Count - 1; i >= 0; i--)
            {
                if (actions[i] != null)
                    actions[i].Invoke();
            }

            for (int i = boolActions.Count - 1; i >= 0; i--)
            {
                if (boolActions[i] != null)
                    boolActions[i].Invoke(value);
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
        public void AddListener(UnityAction<bool> listener)
        {
            boolActions.Add(listener);
        }
        public void RemoveListener(UnityAction<bool> listener)
        {
            boolActions.Remove(listener);
        }
    }
}
