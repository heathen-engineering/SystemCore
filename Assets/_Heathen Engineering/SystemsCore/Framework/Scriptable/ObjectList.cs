using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "List Variables/Object List")]
    public class ObjectList : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public List<GameObject> Values;

        public void AddObject(GameObject go)
        {
            if (!Values.Contains(go))
                Values.Add(go);
        }

        public void RemoveObject(GameObject go)
        {
            Values.Remove(go);
        }
    }
}
