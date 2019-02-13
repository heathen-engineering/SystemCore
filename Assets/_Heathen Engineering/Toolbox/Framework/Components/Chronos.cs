using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.Tools
{
    /// <summary>
    /// Be sure to set Chronos to run before other scripts as its update is gathering time information for use by the others
    /// </summary>
    public class Chronos : MonoBehaviour
    {
        public FloatReference deltaTime;
        public FloatReference unscaledDeltaTime;
        public FloatReference fixedDeltaTime;
        public FloatReference fixedUnscaledDeltaTime;
        
        private void Update()
        {
            deltaTime.Value = Time.deltaTime;
            unscaledDeltaTime.Value = Time.unscaledDeltaTime;
            fixedDeltaTime.Value = Time.fixedDeltaTime;
            fixedUnscaledDeltaTime.Value = Time.fixedUnscaledDeltaTime;
        }
    }
}

