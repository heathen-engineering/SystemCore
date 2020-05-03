using HeathenEngineering.Serializable;
using System;

namespace HeathenEngineering.Scriptable
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
