using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    /// <summary>
    /// <para>Create an event as an object in your project folder.</para>
    /// <para>This represents a general game event ... that is an event defined in your project folder.</para>
    /// </summary>
    [CreateAssetMenu(menuName = "Events/Game Event")]
    public class GameEvent : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public List<GameEventListener> listeners = new List<GameEventListener>();
        public List<UnityAction> actions = new List<UnityAction>();

        public void Raise()
        {
            for(int i = listeners.Count-1; i >= 0; i--)
            {
                if (listeners[i] != null)
                    listeners[i].OnEventRaised();
            }
            for (int i = actions.Count - 1; i >= 0; i--)
            {
                if (actions[i] != null)
                    actions[i].Invoke();
            }
        }

        public void AddListener(GameEventListener listener)
        {
            listeners.Add(listener);
        }
        public void RemoveListener(GameEventListener listener)
        {
            listeners.Remove(listener);
        }
        public void AddListener(UnityAction listener)
        {
            actions.Add(listener);
        }
        public void RemoveListener(UnityAction listener)
        {
            actions.Remove(listener);
        }
    }
}
