#if HE_SYSCORE
using System;
using System.Collections.Generic;

namespace HeathenEngineering
{
    [Serializable]
    public class FloatListReference : VariableReference<List<float>>
    {
        public FloatListVariable Variable;
        public override IDataVariable<List<float>> m_variable => Variable;

        public FloatListReference(List<float> value) : base(value)
        { }
    }
}
#endif