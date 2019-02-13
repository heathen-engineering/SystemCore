using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "Events/Game Event")]
    public class GameEvent : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public List<GameEventListener> listeners; 

        public void Raise()
        {
            for(int i = listeners.Count-1; i >= 0; i--)
            {
                if (listeners[i] != null)
                    listeners[i].OnEventRaised();
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
    }
}
