#if HE_SYSCORE
using System;
using UnityEngine;

namespace HeathenEngineering
{
    [Serializable]
    public class CameraReference : VariableReference<Camera>
    {
        public CameraPointerVariable Variable;
        public override IDataVariable<Camera> m_variable => Variable;

        public CameraReference(Camera value) : base(value)
        { }
    }
}
#endif