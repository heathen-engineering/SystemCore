using HeathenEngineering.Serializable;
using System;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class Vector2IntReference : VariableReference<SerializableVector2Int>
    {
        public SerializableVector2Int ConstantValue;
        public Vector2IntVariable Variable;

        public Vector2IntReference(SerializableVector2Int value)
        {
            Mode = VariableReferenceType.Constant;
            ConstantValue = value;
        }

        public override SerializableVector2Int Value
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

        public static implicit operator SerializableVector2Int(Vector2IntReference reference)
        {
            return reference.Value;
        }
    }
}
