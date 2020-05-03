using System;

namespace HeathenEngineering.Scriptable
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
