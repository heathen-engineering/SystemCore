#if HE_SYSCORE
using System;
using Unity.Mathematics;

namespace HeathenEngineering
{
    [Serializable]
    public class Vector2IntReference : VariableReference<int2>
    {
        public Vector2IntVariable Variable;

        public override IDataVariable<int2> m_variable => Variable;

        public Vector2IntReference(int2 value) : base(value)
        { }
    }
}
#endif