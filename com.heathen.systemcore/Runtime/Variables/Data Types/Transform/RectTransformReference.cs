#if HE_SYSCORE
using HeathenEngineering.Serializable;
using System;

namespace HeathenEngineering
{
    [Serializable]
    public class RectTransformReference : VariableReference<SerializableRectTransform>
    {
        public RectTransformVariable Variable;

        public override IDataVariable<SerializableRectTransform> m_variable => Variable;

        public RectTransformReference(SerializableRectTransform value) : base(value)
        { }
    }
}
#endif