using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.Tools
{
    [AddComponentMenu("System Core/Generic/Transform Register")]
    public class TransformRegister : MonoBehaviour
    {
        public TransformPointerVariable ReferenceVariable;

        private void Start()
        {
            if (ReferenceVariable != null)
                ReferenceVariable.Value = GetComponent<Transform>();
        }

        private void OnDestroy()
        {
            if (ReferenceVariable != null)
                ReferenceVariable.Value = null;
        }
    }
}
