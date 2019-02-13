using HeathenEngineering.Serializable;
using System;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class Vector4Reference : VariableReference<SerializableVector4>
    {
        public SerializableVector4 ConstantValue;
        public Vector4Variable Variable;

        public Vector4Reference(SerializableVector4 value)
        {
            Mode = VariableReferenceType.Constant;
            ConstantValue = value;
        }

        public override SerializableVector4 Value
        {
            get { return Mode != VariableReferenceType.Referenced || Variable == null ? ConstantValue : Variable.Value; }
            set
            {
                if (Mode != VariableReferenceType.Static)
                {
                    if (Mode == VariableReferenceType.Referenced && Variable != null)
                        Variable.SetValue(value);
                    else
                        ConstantValue = value;
                }
            }
        }

        public static implicit operator SerializableVector4(Vector4Reference reference)
        {
            return reference.Value;
        }
    }
}
