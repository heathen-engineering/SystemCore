#if HE_SYSCORE
using System;
using UnityEngine;

namespace HeathenEngineering
{
    [Serializable]
    public class CanvasReference : VariableReference<Canvas>
    {
        public CanvasPointerVariable Variable;
        public override IDataVariable<Canvas> m_variable => Variable;

        public CanvasReference(Canvas value) : base(value)
        { }
    }
}
#endif