using HeathenEngineering.Serializable;
using System;
using System.Collections.Generic;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class Vector4ListReference : VariableReference<List<SerializableVector4>>
    {
        public Vector4ListVariable Variable;
        public override IDataVariable<List<SerializableVector4>> m_variable => Variable;

        public Vector4ListReference(List<SerializableVector4> value) : base(value)
        { }
    }
}
