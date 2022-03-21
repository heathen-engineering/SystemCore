#if HE_SYSCORE
using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace HeathenEngineering
{
    [Serializable]
    public class Vector4ListReference : VariableReference<List<float4>>
    {
        public Vector4ListVariable Variable;
        public override IDataVariable<List<float4>> m_variable => Variable;

        public Vector4ListReference(List<float4> value) : base(value)
        { }
    }
}
#endif