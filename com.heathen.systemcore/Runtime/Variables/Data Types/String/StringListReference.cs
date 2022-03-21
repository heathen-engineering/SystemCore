#if HE_SYSCORE
using System;
using System.Collections.Generic;

namespace HeathenEngineering
{
    [Serializable]
    public class StringListReference : VariableReference<List<string>>
    {
        public StringListVariable Variable;
        public override IDataVariable<List<string>> m_variable => Variable;

        public StringListReference(List<string> value) : base(value)
        { }
    }
}
#endif