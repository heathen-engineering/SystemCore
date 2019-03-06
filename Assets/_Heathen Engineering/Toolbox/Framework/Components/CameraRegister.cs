using UnityEngine;
using HeathenEngineering.Scriptable;
using System;

namespace HeathenEngineering.Tools
{
    [RequireComponent(typeof(Camera))]
    [AddComponentMenu("Heathen/Camera/Camera Register")]
    public class CameraRegister : MonoBehaviour
    {
        public CameraVariable ReferenceVariable;

        private void Start()
        {
            if (ReferenceVariable != null)
                ReferenceVariable.camera = GetComponent<Camera>();
        }

        private void OnDestroy()
        {
            if (ReferenceVariable != null)
                ReferenceVariable.camera = null;
        }
    }
}
