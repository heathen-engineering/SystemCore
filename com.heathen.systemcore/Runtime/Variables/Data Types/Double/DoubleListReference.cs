#if HE_SYSCORE
using System;
using System.Collections.Generic;

namespace HeathenEngineering
{
    [Serializable]
    public class DoubleListReference : VariableReference<List<double>>
    {
        public DoubleListVariable Variable;
        public override IDataVariable<List<double>> m_variable => Variable;

        public DoubleListReference(List<double> value) : base(value)
        { }
    }
}
#endif