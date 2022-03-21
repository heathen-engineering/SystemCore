#if HE_SYSCORE
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering
{
    /// <summary>
    /// Used as the base class for UI specific behaviours
    /// </summary>
    public class HeathenUIBehaviour : MonoBehaviour
    {
        public List<ScriptableObject> tags;

        private RectTransform _selfTransform;
        public RectTransform SelfTransform
        {
            get
            {
                if (_selfTransform == null)
                    _selfTransform = GetComponent<RectTransform>();
                return _selfTransform;
            }
        }

        public bool ContainsScriptableTag(ScriptableObject tag) => tags.Contains(tag);
        public bool ContainsScriptableTags(IEnumerable<ScriptableObject> tags)
        {
            foreach (var tag in tags)
            {
                if (!this.tags.Contains(tag))
                    return false;
            }

            return true;
        }
    }
}
#endif