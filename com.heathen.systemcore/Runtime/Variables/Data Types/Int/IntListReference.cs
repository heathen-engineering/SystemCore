#if HE_SYSCORE
using System;
using System.Collections.Generic;

namespace HeathenEngineering
{
    [Serializable]
    public class IntListReference : VariableReference<List<int>>
    {
        public IntListVariable Variable;
        public override IDataVariable<List<int>> m_variable => Variable;

        public IntListReference(List<int> value) : base(value)
        { }
    }
}
#endif