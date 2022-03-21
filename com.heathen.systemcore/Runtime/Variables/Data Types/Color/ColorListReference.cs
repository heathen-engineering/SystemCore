#if HE_SYSCORE
using HeathenEngineering.Serializable;
using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace HeathenEngineering
{
    [Serializable]
    public class ColorListReference : VariableReference<List<float4>>
    {
        public ColorListVariable Variable;
        public override IDataVariable<List<float4>> m_variable => Variable;

        public ColorListReference(List<float4> value) : base(value)
        { }
    }
}
#endif