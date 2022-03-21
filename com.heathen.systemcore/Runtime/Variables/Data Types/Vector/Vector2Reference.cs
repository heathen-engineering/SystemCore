#if HE_SYSCORE
using System;
using Unity.Mathematics;

namespace HeathenEngineering
{
    [Serializable]
    public class Vector2Reference : VariableReference<float2>
    {
        public Vector2Variable Variable;

        public override IDataVariable<float2> m_variable => Variable;

        public Vector2Reference(float2 value) : base(value)
        { }
    }
}
#endif