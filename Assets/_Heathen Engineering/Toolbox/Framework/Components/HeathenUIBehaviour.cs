using UnityEngine;

namespace HeathenEngineering.Tools
{
    /// <summary>
    /// Used as the base class for UI specific behaviours
    /// </summary>
    public class HeathenUIBehaviour : MonoBehaviour
    {
        private RectTransform _selfTransform;
        public RectTransform selfTransform
        {
            get
            {
                if (_selfTransform == null)
                    _selfTransform = GetComponent<RectTransform>();
                return _selfTransform;
            }
        }
    }
}
