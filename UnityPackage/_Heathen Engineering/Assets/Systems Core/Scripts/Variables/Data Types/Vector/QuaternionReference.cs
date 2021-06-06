using HeathenEngineering.Serializable;
using System;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class QuaternionReference : VariableReference<SerializableQuaternion>
    {
        public QuaternionVariable Variable;

        public override IDataVariable<SerializableQuaternion> m_variable => Variable;

        public QuaternionReference(SerializableQuaternion value) : base(value)
        { }
    }
}
