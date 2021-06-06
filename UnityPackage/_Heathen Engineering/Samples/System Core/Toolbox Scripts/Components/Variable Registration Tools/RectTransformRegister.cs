using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.Tools
{
    [RequireComponent(typeof(RectTransform))]
    [AddComponentMenu("System Core/Tools/Rect Transform Register")]
    public class RectTransformRegister : MonoBehaviour
    {
        public RectTransformPointerVariable ReferenceVariable;

        private void Start()
        {
            if (ReferenceVariable != null)
                ReferenceVariable.Value = GetComponent<RectTransform>();
        }

        private void OnDestroy()
        {
            if (ReferenceVariable != null)
                ReferenceVariable.Value = null;
        }
    }
}
