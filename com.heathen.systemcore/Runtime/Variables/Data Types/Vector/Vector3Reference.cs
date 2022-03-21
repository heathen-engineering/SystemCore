#if HE_SYSCORE
using System;
using Unity.Mathematics;

namespace HeathenEngineering
{
    [Serializable]
    public class Vector3Reference : VariableReference<float3>
    {
        public Vector3Variable Variable;

        public override IDataVariable<float3> m_variable => Variable;

        public Vector3Reference(float3 value) : base(value)
        { }
    }
}
#endif