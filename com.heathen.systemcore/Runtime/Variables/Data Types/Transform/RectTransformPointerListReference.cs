#if HE_SYSCORE
using System;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering
{
    [Serializable]
    public class RectTransformPointerListReference : VariableReference<List<RectTransform>>
    {
        public RectTransformPointerListVariable Variable;
        public override IDataVariable<List<RectTransform>> m_variable => Variable;

        public RectTransformPointerListReference(List<RectTransform> value) : base(value)
        { }
    }
}
#endif