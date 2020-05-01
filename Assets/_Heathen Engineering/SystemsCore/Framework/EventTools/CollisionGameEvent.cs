using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
    /// <summary>
    /// <para>Create an event as an object in your project folder.</para>
    /// <para>This represents a collision game event ... that is an event defined in your project folder that sends collision data when raised.</para>
    /// </summary>
    [CreateAssetMenu(menuName = "Events/Collision Game Event")]
    public class CollisionGameEvent : GameEvent 
    {
        public List<CollisionGameEventListener> collisionListeners = new List<CollisionGameEventListener>();
        public List<UnityAction<Collision>> collisionActions = new List<UnityAction<Collision>>();

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

            for (int i = actions.Count - 1; i >= 0; i--)
            {
                if (actions[i] != null)
                    actions[i].Invoke();
            }

            for (int i = collisionActions.Count - 1; i >= 0; i--)
            {
                if (collisionActions[i] != null)
                    collisionActions[i].Invoke(collider);
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
        public void AddListener(UnityAction<Collision> listener)
        {
            collisionActions.Add(listener);
        }
        public void RemoveListener(UnityAction<Collision> listener)
        {
            collisionActions.Remove(listener);
        }
    }
}
