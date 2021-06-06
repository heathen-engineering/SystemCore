using System;
using System.Collections.Generic;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class UnsignedLongListReference : VariableReference<List<ulong>>
    {
        public UnsignedLongListVariable Variable;
        public override IDataVariable<List<ulong>> m_variable => Variable;

        public UnsignedLongListReference(List<ulong> value) : base(value)
        { }
    }
}
