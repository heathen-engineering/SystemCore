#if HE_SYSCORE
using System;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering
{
    [Serializable]
    public class CanvasListReference : VariableReference<List<Canvas>>
    {
        public CanvasPointerListVariable Variable;
        public override IDataVariable<List<Canvas>> m_variable => Variable;

        public CanvasListReference(List<Canvas> value) : base(value)
        { }
    }
}
#endif