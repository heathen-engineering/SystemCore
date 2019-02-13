using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.Tools
{
    [RequireComponent(typeof(RectTransform))]
    [AddComponentMenu("Heathen/Generic/Rect Transform Register")]
    public class RectTransformRegister : MonoBehaviour
    {
        public RectTransformVariable ReferenceVariable;

        private void Start()
        {
            if (ReferenceVariable != null)
                ReferenceVariable.rectTransform = GetComponent<RectTransform>();
        }

        private void OnDestroy()
        {
            if (ReferenceVariable != null)
                ReferenceVariable.rectTransform = null;
        }
    }
}
