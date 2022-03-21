#if HE_SYSCORE
using System;
using Unity.Mathematics;

namespace HeathenEngineering
{
    [Serializable]
    public class QuaternionReference : VariableReference<quaternion>
    {
        public QuaternionVariable Variable;

        public override IDataVariable<quaternion> m_variable => Variable;

        public QuaternionReference(quaternion value) : base(value)
        { }
    }
}
#endif