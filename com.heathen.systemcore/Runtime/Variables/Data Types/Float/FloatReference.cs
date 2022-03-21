#if HE_SYSCORE
using System;

namespace HeathenEngineering
{
    [Serializable]
    public class FloatReference : VariableReference<float>
    {
        public FloatVariable Variable;

        public override IDataVariable<float> m_variable => Variable;

        public FloatReference(float value) : base(value)
        { }
    }
}
#endif