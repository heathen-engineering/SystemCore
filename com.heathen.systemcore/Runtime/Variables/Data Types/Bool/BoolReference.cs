#if HE_SYSCORE
using System;

namespace HeathenEngineering
{
    [Serializable]
    public class BoolReference : VariableReference<bool>
    {
        public BoolVariable Variable;
        public override IDataVariable<bool> m_variable => Variable;

        public BoolReference(bool value) : base(value)
        { }

        public void ToggleValue()
        {
            Value = !Value;
        }
    }
}
#endif