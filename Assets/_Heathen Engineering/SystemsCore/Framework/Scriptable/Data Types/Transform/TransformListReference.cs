using HeathenEngineering.Serializable;
using System;
using System.Collections.Generic;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class TransformListReference : VariableReference<List<SerializableTransform>>
    {
        public TransformListVariable Variable;
        public override IDataVariable<List<SerializableTransform>> m_variable => Variable;

        public TransformListReference(List<SerializableTransform> value) : base(value)
        { }
    }
}
