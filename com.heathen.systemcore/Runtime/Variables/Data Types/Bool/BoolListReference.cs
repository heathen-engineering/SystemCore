#if HE_SYSCORE
using System;
using System.Collections.Generic;

namespace HeathenEngineering
{
    [Serializable]
    public class BoolListReference : VariableReference<List<bool>>
    {
        public BoolListVariable Variable;
        public override IDataVariable<List<bool>> m_variable => Variable;

        public BoolListReference(List<bool> value) : base(value)
        { }
    }
}
#endif