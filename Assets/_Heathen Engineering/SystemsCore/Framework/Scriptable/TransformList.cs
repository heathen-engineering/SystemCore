using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "List Variables/Transform List")]
    public class TransformList : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public List<Transform> Values;

        public void AddObject(Transform transform)
        {
            if (!Values.Contains(transform))
                Values.Add(transform);
        }

        public void RemoveObject(Transform transform)
        {
            Values.Remove(transform);
        }
    }
}
