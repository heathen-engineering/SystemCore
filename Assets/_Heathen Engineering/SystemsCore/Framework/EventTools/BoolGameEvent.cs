using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    /// <summary>
    /// <para>Create an event as an object in your project folder.</para>
    /// <para>This represents a bool game event ... that is an event defined in your project folder that sends a bool when raised.</para>
    /// </summary>
    [CreateAssetMenu(menuName = "Events/Bool Game Event")]
    public class BoolGameEvent : GameEvent
    {
        /// <summary>
        /// The list of <see cref="BoolGameEventListener"/> objects registered to listen on this event
        /// </summary>
        public List<BoolGameEventListener> boolListeners = new List<BoolGameEventListener>();
        /// <summary>
        /// The list of UnityAction deligates listening on this event
        /// </summary>
        public List<UnityAction<bool>> boolActions = new List<UnityAction<bool>>();

        /// <summary>
        /// Raises the event sending the value along with it
        /// </summary>
        /// <param name="value">The value to send</param>
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

        /// <summary>
        /// Adds a <see cref="BoolGameEventListener"/> to the listeners list
        /// </summary>
        /// <param name="listener"></param>
        public void AddListener(BoolGameEventListener listener)
        {
            boolListeners.Add(listener);
        }
        /// <summary>
        /// Removes a <see cref="BoolGameEventListener"/> from the listeners list
        /// </summary>
        /// <param name="listener"></param>
        public void RemoveListener(BoolGameEventListener listener)
        {
            boolListeners.Remove(listener);
        }
        /// <summary>
        /// Adds a UnityAction to the listeners list
        /// </summary>
        /// <param name="listener"></param>
        public void AddListener(UnityAction<bool> listener)
        {
            boolActions.Add(listener);
        }
        /// <summary>
        /// Removes a UnityAction from the listeners list
        /// </summary>
        /// <param name="listener"></param>
        public void RemoveListener(UnityAction<bool> listener)
        {
            boolActions.Remove(listener);
        }
    }
}
