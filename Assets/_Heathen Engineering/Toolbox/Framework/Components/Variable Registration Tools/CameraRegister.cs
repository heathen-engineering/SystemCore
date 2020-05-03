using UnityEngine;
using HeathenEngineering.Scriptable;
using System;

namespace HeathenEngineering.Tools
{
    [RequireComponent(typeof(Camera))]
    [AddComponentMenu("System Core/Tools/Camera Register")]
    public class CameraRegister : MonoBehaviour
    {
        public CameraPointerVariable ReferenceVariable;

        private void Start()
        {
            if (ReferenceVariable != null)
                ReferenceVariable.Value = GetComponent<Camera>();
        }

        private void OnDestroy()
        {
            if (ReferenceVariable != null)
                ReferenceVariable.Value = null;
        }
    }
}
