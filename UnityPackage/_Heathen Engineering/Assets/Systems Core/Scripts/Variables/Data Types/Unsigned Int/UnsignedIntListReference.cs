using System;
using System.Collections.Generic;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class UnsignedIntListReference : VariableReference<List<uint>>
    {
        public UnsignedIntListVariable Variable;
        public override IDataVariable<List<uint>> m_variable => Variable;

        public UnsignedIntListReference(List<uint> value) : base(value)
        { }
    }
}
