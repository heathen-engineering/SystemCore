#if HE_SYSCORE
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Application/Keyed String List")]
    public class KeyedStringListVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public string OpenTag = "@[";
        public string CloseTag = "];";
        public int MaxDepth = 10;
        public List<KeyedReference> Values;

        public void SetValue(List<KeyedReference> value)
        {
            Values.Clear();
            Values.AddRange(value);
        }

        public void SetValue(KeyedStringListVariable value)
        {
            Values.Clear();
            Values.AddRange(value.Values);
        }

        public string GetValue(string key)
        {
            if (Values.Any(p => p.Key == key))
                return SwapKeys(Values.First(p => p.Key == key).Value);
            else
                return string.Empty;
        }

        /// <summary>
        /// Replaces all occurences of keys from this list with there values
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        /// <remarks>
        /// This is a lazy swap and can be greatly optimized by walking the source string
        /// This can be further optimized by indexing the values
        /// We should also recomend that lists be keep as short as possible e.g. field labels seperate from dialog messages for example to reduce the swap time
        /// </remarks>
        public string SwapKeys(string source)
        {
            int loopBlock = 0;
            string working = source;
            while (working.Contains(OpenTag) && loopBlock < MaxDepth)
            {
                loopBlock++;
                StringBuilder build = new StringBuilder(working);
                foreach (KeyedReference r in Values)
                {
                    build = build.Replace(OpenTag + r.Key + CloseTag, r.Value.Value);
                }
                working = build.ToString();
            }

            return working;
        }
    }
}
#endif