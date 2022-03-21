#if HE_SYSCORE
using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace HeathenEngineering
{
    [Serializable]
    public class Vector2ListReference : VariableReference<List<float2>>
    {
        public Vector2ListVariable Variable;
        public override IDataVariable<List<float2>> m_variable => Variable;

        public Vector2ListReference(List<float2> value) : base(value)
        { }
    }
}
#endif