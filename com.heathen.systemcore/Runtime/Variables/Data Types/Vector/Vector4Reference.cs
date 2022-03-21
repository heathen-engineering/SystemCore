#if HE_SYSCORE
using System;
using Unity.Mathematics;

namespace HeathenEngineering
{
    [Serializable]
    public class Vector4Reference : VariableReference<float4>
    {
        public Vector4Variable Variable;

        public override IDataVariable<float4> m_variable => Variable;

        public Vector4Reference(float4 value) : base(value)
        { }
    }
}
#endif