#if HE_SYSCORE
using System;

namespace HeathenEngineering
{
    [Serializable]
    public class DoubleReference : VariableReference<double>
    {
        public DoubleVariable Variable;

        public override IDataVariable<double> m_variable => Variable;

        public DoubleReference(double value) : base(value)
        { }
    }
}
#endif