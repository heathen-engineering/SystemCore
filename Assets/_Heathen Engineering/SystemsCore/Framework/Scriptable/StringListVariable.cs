using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "List Variables/String List")]
    public class StringListVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public List<StringReference> Values;

        public void SetValue(List<StringReference> value)
        {
            Values.Clear();
            Values.AddRange(value);
        }

        public void SetValue(StringListVariable value)
        {
            Values.Clear();
            Values.AddRange(value.Values);
        }
    }
}
