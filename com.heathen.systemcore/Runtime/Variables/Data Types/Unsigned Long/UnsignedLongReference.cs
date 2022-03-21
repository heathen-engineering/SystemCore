#if HE_SYSCORE
using System;

namespace HeathenEngineering
{
    [Serializable]
    public class UnsignedLongReference : VariableReference<ulong>
    {
        public UnsignedLongVariable Variable;
        public override IDataVariable<ulong> m_variable => Variable;

        public UnsignedLongReference(ulong value) : base(value)
        { }
    }
}
#endif