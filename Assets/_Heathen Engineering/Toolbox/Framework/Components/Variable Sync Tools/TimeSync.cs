using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.Tools
{
    public class TimeSync : MonoBehaviour
    {
        public FloatReference deltaTime;
        public FloatReference unscaledDeltaTime;
        public FloatReference fixedDeltaTime;
        public FloatReference fixedUnscaledDeltaTime;
        
        private void Update()
        {
            deltaTime.Value = Time.deltaTime;
            unscaledDeltaTime.Value = Time.unscaledDeltaTime;
        }

        private void FixedUpdate()
        {
            fixedDeltaTime.Value = Time.fixedDeltaTime;
            fixedUnscaledDeltaTime.Value = Time.fixedUnscaledDeltaTime;
        }
    }
}

