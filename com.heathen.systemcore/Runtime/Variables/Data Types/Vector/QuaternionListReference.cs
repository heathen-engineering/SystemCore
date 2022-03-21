#if HE_SYSCORE
using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace HeathenEngineering
{
    [Serializable]
    public class QuaternionListReference : VariableReference<List<quaternion>>
    {
        public QuaternionListVariable Variable;
        public override IDataVariable<List<quaternion>> m_variable => Variable;

        public QuaternionListReference(List<quaternion> value) : base(value)
        { }
    }
}
#endif