using HeathenEngineering.Serializable;
using System;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class Vector3Reference : VariableReference<SerializableVector3>
    {
        public Vector3Variable Variable;

        public override IDataVariable<SerializableVector3> m_variable => Variable;

        public Vector3Reference(SerializableVector3 value) : base(value)
        { }
    }
}
