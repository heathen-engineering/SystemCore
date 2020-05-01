using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    /// <summary>
    /// <para>Create an event as an object in your project folder.</para>
    /// <para>This represents a int game event ... that is an event defined in your project folder that sends a int when raised.</para>
    /// </summary>
    [CreateAssetMenu(menuName = "Events/Int Game Event")]
    public class IntGameEvent : GameEvent
    {
        public List<IntGameEventListener> intListeners = new List<IntGameEventListener>();
        public List<UnityAction<int>> intActions = new List<UnityAction<int>>();

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

            for (int i = actions.Count - 1; i >= 0; i--)
            {
                if (actions[i] != null)
                    actions[i].Invoke();
            }

            for (int i = intListeners.Count - 1; i >= 0; i--)
            {
                if (intActions[i] != null)
                    intActions[i].Invoke(value);
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
        public void AddListener(UnityAction<int> listener)
        {
            intActions.Add(listener);
        }
        public void RemoveListener(UnityAction<int> listener)
        {
            intActions.Remove(listener);
        }
    }
}
