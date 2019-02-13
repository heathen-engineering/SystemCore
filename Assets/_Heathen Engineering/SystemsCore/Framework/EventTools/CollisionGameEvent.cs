using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "Events/Collision Game Event")]
    public class CollisionGameEvent : GameEvent
    {
        public List<CollisionGameEventListener> collisionListeners;

        public void Raise(Collision collider)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                if (listeners[i] != null)
                    listeners[i].OnEventRaised();
            }

            for (int i = collisionListeners.Count - 1; i >= 0; i--)
            {
                if (collisionListeners[i] != null)
                    collisionListeners[i].OnEventRaised(collider);
            }
        }

        public void AddListener(CollisionGameEventListener listener)
        {
            collisionListeners.Add(listener);
        }
        public void RemoveListener(CollisionGameEventListener listener)
        {
            collisionListeners.Remove(listener);
        }
    }
}
