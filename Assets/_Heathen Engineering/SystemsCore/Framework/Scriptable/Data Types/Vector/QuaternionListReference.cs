using HeathenEngineering.Serializable;
using System;
using System.Collections.Generic;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class QuaternionListReference : VariableReference<List<SerializableQuaternion>>
    {
        public QuaternionListVariable Variable;
        public override IDataVariable<List<SerializableQuaternion>> m_variable => Variable;

        public QuaternionListReference(List<SerializableQuaternion> value) : base(value)
        { }
    }
}
