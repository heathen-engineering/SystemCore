#if HE_SYSCORE
using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace HeathenEngineering
{
    [Serializable]
    public class Vector2IntListReference : VariableReference<List<int2>>
    {
        public Vector2IntListVariable Variable;
        public override IDataVariable<List<int2>> m_variable => Variable;

        public Vector2IntListReference(List<int2> value) : base(value)
        { }
    }
}
#endif