using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    /// <summary>
    /// <para>Create an event as an object in your project folder.</para>
    /// <para>This represents a string game event ... that is an event defined in your project folder that sends a string when raised.</para>
    /// </summary>
    [CreateAssetMenu(menuName = "Events/String Game Event")]
    public class StringGameEvent : GameEvent
    {
        public List<StringGameEventListener> stringListeners = new List<StringGameEventListener>();
        public List<UnityAction<string>> stringActions = new List<UnityAction<string>>();

        public void Raise(string value)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                if (listeners[i] != null)
                    listeners[i].OnEventRaised();
            }

            for (int i = stringListeners.Count - 1; i >= 0; i--)
            {
                if (stringListeners[i] != null)
                    stringListeners[i].OnEventRaised(value);
            }

            for (int i = actions.Count - 1; i >= 0; i--)
            {
                if (actions[i] != null)
                    actions[i].Invoke();
            }

            for (int i = stringActions.Count - 1; i >= 0; i--)
            {
                if (stringActions[i] != null)
                    stringActions[i].Invoke(value);
            }
        }

        public void AddListener(StringGameEventListener listener)
        {
            stringListeners.Add(listener);
        }
        public void RemoveListener(StringGameEventListener listener)
        {
            stringListeners.Remove(listener);
        }
        public void AddListener(UnityAction<string> listener)
        {
            stringActions.Add(listener);
        }
        public void RemoveListener(UnityAction<string> listener)
        {
            stringActions.Remove(listener);
        }
    }
}
