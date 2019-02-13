using HeathenEngineering.Serializable;
using System;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class Vector2Reference : VariableReference<SerializableVector2>
    {
        public SerializableVector2 ConstantValue;
        public Vector2Variable Variable;

        public Vector2Reference(SerializableVector2 value)
        {
            Mode = VariableReferenceType.Constant;
            ConstantValue = value;
        }

        public override SerializableVector2 Value
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

        public static implicit operator SerializableVector2(Vector2Reference reference)
        {
            return reference.Value;
        }
    }
}
