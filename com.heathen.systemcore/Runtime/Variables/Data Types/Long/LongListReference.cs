#if HE_SYSCORE
using System;
using System.Collections.Generic;

namespace HeathenEngineering
{
    [Serializable]
    public class LongListReference : VariableReference<List<long>>
    {
        public LongListVariable Variable;
        public override IDataVariable<List<long>> m_variable => Variable;

        public LongListReference(List<long> value) : base(value)
        { }
    }
}
#endif