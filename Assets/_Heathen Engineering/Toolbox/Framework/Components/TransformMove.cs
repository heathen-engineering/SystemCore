using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.Tools
{
    public class TransformMove : HeathenBehaviour
    {
        [Tooltip("If true the value in deltaTime will be used insted of Time.deltaTime, " +
            "this can be more performant if you have a deltaTime variable that is already populated such as by using Chronos.")]
        public bool useReferencedTime;
        public FloatReference deltaTime;
        public Vector3Reference localPositionSpeed;

        private void Update()
        {
            if (useReferencedTime)
                selfTransform.localPosition += ((Vector3)localPositionSpeed.Value) * deltaTime;
            else
                selfTransform.localPosition += ((Vector3)localPositionSpeed.Value) * Time.deltaTime;
        }
    }
}

