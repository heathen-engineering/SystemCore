using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.Tools
{
    [AddComponentMenu("Heathen/Generic/Transform Register")]
    public class TransformRegister : MonoBehaviour
    {
        public TransformVariable ReferenceVariable;

        private void Start()
        {
            if (ReferenceVariable != null)
                ReferenceVariable.transform = GetComponent<Transform>();
        }

        private void OnDestroy()
        {
            if (ReferenceVariable != null)
                ReferenceVariable.transform = null;
        }
    }
}
