#if HE_SYSCORE
using System;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering
{
    [Serializable]
    public class TransformPointerListReference : VariableReference<List<Transform>>
    {
        public TransformPointerListVariable Variable;
        public override IDataVariable<List<Transform>> m_variable => Variable;

        public TransformPointerListReference(List<Transform> value) : base(value)
        { }
    }
}
#endif