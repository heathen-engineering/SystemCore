#if HE_SYSCORE
using HeathenEngineering.Serializable;
using System;

namespace HeathenEngineering
{
    [Serializable]
    public class TransformReference : VariableReference<SerializableTransform>
    {
        public TransformVariable Variable;

        public override IDataVariable<SerializableTransform> m_variable => Variable;

        public TransformReference(SerializableTransform value) : base(value)
        { }
    }
}
#endif