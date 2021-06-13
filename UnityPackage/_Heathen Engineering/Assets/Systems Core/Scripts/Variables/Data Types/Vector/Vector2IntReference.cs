using HeathenEngineering.Serializable;
using System;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class Vector2IntReference : VariableReference<SerializableVector2Int>
    {
        public Vector2IntVariable Variable;

        public override IDataVariable<SerializableVector2Int> m_variable => Variable;

        public Vector2IntReference(SerializableVector2Int value) : base(value)
        { }
    }
}
