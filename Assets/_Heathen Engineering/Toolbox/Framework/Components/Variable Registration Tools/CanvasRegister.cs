using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.Tools
{
    [RequireComponent(typeof(Canvas))]
    [AddComponentMenu("System Core/Canvas/Canvas Register")]
    public class CanvasRegister : MonoBehaviour
    {
        public CanvasPointerVariable ReferenceVariable;

        private void Start()
        {
            if (ReferenceVariable != null)
                ReferenceVariable.Value = GetComponent<Canvas>();
        }

        private void OnDestroy()
        {
            if (ReferenceVariable != null)
                ReferenceVariable.Value = null;
        }
    }
}
