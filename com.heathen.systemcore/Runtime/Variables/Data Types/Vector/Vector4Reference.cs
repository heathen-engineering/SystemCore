using HeathenEngineering.Serializable;
using System;

namespace HeathenEngineering
{
    [Serializable]
    public class Vector4Reference : VariableReference<SerializableVector4>
    {
        public Vector4Variable Variable;

        public override IDataVariable<SerializableVector4> m_variable => Variable;

        public Vector4Reference(SerializableVector4 value) : base(value)
        { }
    }
}
