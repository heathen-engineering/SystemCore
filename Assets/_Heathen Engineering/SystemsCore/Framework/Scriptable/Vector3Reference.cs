using HeathenEngineering.Serializable;
using System;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class Vector3Reference : VariableReference<SerializableVector3>
    {
        public SerializableVector3 ConstantValue;
        public Vector3Variable Variable;

        public Vector3Reference(SerializableVector3 value)
        {
            Mode = VariableReferenceType.Constant;
            ConstantValue = value;
        }

        public override SerializableVector3 Value
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

        public static implicit operator SerializableVector3(Vector3Reference reference)
        {
            return reference.Value;
        }
    }
}
