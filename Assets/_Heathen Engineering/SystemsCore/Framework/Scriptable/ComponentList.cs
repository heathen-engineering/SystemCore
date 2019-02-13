using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "List Variables/Component List")]
    public class ComponentList : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public List<Component> Values;
        
        public void AddComponent(Component subjectComponent)
        {
            if (!Values.Contains(subjectComponent))
                Values.Add(subjectComponent);
        }

        public void RemoveComponent(Component subjectComponent)
        {
            Values.Remove(subjectComponent);
        }

        public List<T> GetValues<T>() where T : Component
        {
            List<T> results = new List<T>();
            foreach(var c in Values.Where(p => p.GetType() == typeof(T)))
            {
                results.Add(c as T);
            }

            return results;
        }
    }
}
