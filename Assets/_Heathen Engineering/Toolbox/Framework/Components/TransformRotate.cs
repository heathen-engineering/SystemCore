using HeathenEngineering.Scriptable;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Tools
{

    public class TransformRotate : HeathenBehaviour
    {
        [Tooltip("If true the value in deltaTime will be used insted of Time.deltaTime, " +
            "this can be more performant if you have a deltaTime variable that is already populated such as by using Chronos.")]
        public bool useReferencedTime;
        public FloatReference deltaTime;
        public Vector3Reference localRotationSpeed;
        
        private void Update()
        {
            if (useReferencedTime)
                selfTransform.localEulerAngles += ((Vector3)localRotationSpeed.Value) * deltaTime;
            else
                selfTransform.localEulerAngles += ((Vector3)localRotationSpeed.Value) * Time.deltaTime;
        }
    }
}

