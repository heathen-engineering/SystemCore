using HeathenEngineering.Serializable;
using System;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class ColorReference : VariableReference<SerializableColor>
    {
        public SerializableColor ConstantValue;
        public ColorVariable Variable;

        public ColorReference(Color value)
        {
            Mode = VariableReferenceType.Constant;
            ConstantValue = value;
        }

        public override SerializableColor Value
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

        public static implicit operator Color(ColorReference reference)
        {
            return reference.Value;
        }
    }
}
