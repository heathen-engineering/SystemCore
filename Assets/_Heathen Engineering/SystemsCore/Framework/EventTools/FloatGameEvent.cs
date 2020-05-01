using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    /// <summary>
    /// <para>Create an event as an object in your project folder.</para>
    /// <para>This represents a float game event ... that is an event defined in your project folder that sends a float when raised.</para>
    /// </summary>
    [CreateAssetMenu(menuName = "Events/Float Game Event")]
    public class FloatGameEvent : GameEvent
    {
        public List<FloatGameEventListener> floatListeners = new List<FloatGameEventListener>();
        public List<UnityAction<float>> floatActions = new List<UnityAction<float>>();

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

            for (int i = actions.Count - 1; i >= 0; i--)
            {
                if (actions[i] != null)
                    actions[i].Invoke();
            }

            for (int i = floatActions.Count - 1; i >= 0; i--)
            {
                if (floatActions[i] != null)
                    floatActions[i].Invoke(value);
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
        public void AddListener(UnityAction<float> listener)
        {
            floatActions.Add(listener);
        }
        public void RemoveListener(UnityAction<float> listener)
        {
            floatActions.Remove(listener);
        }
    }
}
