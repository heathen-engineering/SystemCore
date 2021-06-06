using HeathenEngineering.Serializable;
using System;
using System.Collections.Generic;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class Vector2IntListReference : VariableReference<List<SerializableVector2Int>>
    {
        public Vector2IntListVariable Variable;
        public override IDataVariable<List<SerializableVector2Int>> m_variable => Variable;

        public Vector2IntListReference(List<SerializableVector2Int> value) : base(value)
        { }
    }
}
