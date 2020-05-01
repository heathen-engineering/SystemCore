using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    /// <summary>
    /// <para>Create an event as an object in your project folder.</para>
    /// <para>This represents a trigger game event ... that is an event defined in your project folder that sends collider data when raised.</para>
    /// </summary>
    [CreateAssetMenu(menuName = "Events/Trigger Game Event")]
    public class TriggerGameEvent : GameEvent
    {
        public List<TriggerGameEventListener> triggerListeners = new List<TriggerGameEventListener>();
        public List<UnityAction<Collider>> triggerActions = new List<UnityAction<Collider>>();

        public void Raise(Collider collider)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                if (listeners[i] != null)
                    listeners[i].OnEventRaised();
            }

            for (int i = triggerListeners.Count - 1; i >= 0; i--)
            {
                if (triggerListeners[i] != null)
                    triggerListeners[i].OnEventRaised(collider);
            }

            for (int i = actions.Count - 1; i >= 0; i--)
            {
                if (actions[i] != null)
                    actions[i].Invoke();
            }

            for (int i = triggerActions.Count - 1; i >= 0; i--)
            {
                if (triggerActions[i] != null)
                    triggerActions[i].Invoke(collider);
            }
        }

        public void AddListener(TriggerGameEventListener listener)
        {
            triggerListeners.Add(listener);
        }
        public void RemoveListener(TriggerGameEventListener listener)
        {
            triggerListeners.Remove(listener);
        }
        public void AddListener(UnityAction<Collider> listener)
        {
            triggerActions.Add(listener);
        }
        public void RemoveListener(UnityAction<Collider> listener)
        {
            triggerActions.Remove(listener);
        }
    }
}
