using System;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class LongReference : VariableReference<long>
    {
        public LongVariable Variable;
        public override IDataVariable<long> m_variable => Variable;

        public LongReference(long value) : base(value)
        { }
    }
}
