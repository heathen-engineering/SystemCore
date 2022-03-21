#if HE_SYSCORE
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering
{
    /// <summary>
    /// Used as the base class for traditional Transform based behaviours
    /// </summary>
    public class HeathenBehaviour : MonoBehaviour
    {
        public List<ScriptableObject> tags;

        private Transform _selfTransform;
        public Transform SelfTransform
        {
            get
            {
                if (_selfTransform == null)
                    _selfTransform = GetComponent<Transform>();
                return _selfTransform;
            }
        }

        public bool ContainsScriptableTag(ScriptableObject tag) => tags.Contains(tag);
        public bool ContainsScriptableTags(IEnumerable<ScriptableObject> tags)
        {
            foreach(var tag in tags)
            {
                if (!this.tags.Contains(tag))
                    return false;
            }

            return true;
        }
    }
}
#endif