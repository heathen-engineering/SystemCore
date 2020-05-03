using HeathenEngineering.Serializable;
using System;
using System.Collections.Generic;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class Vector2ListReference : VariableReference<List<SerializableVector2>>
    {
        public Vector2ListVariable Variable;
        public override IDataVariable<List<SerializableVector2>> m_variable => Variable;

        public Vector2ListReference(List<SerializableVector2> value) : base(value)
        { }
    }
}
