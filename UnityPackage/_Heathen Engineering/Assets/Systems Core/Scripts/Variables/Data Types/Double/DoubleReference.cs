using System;

namespace HeathenEngineering.Scriptable
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
