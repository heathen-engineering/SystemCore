#if HE_SYSCORE
using System;

namespace HeathenEngineering
{
    [Serializable]
    public class StringReference : VariableReference<string>
    {
        public StringVariable Variable;

        public override IDataVariable<string> m_variable => Variable;

        public StringReference(string value) : base(value)
        { }
    }
}
#endif