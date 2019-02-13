using System;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class StringReference : VariableReference<string>
    {
        [Multiline]
        public string ConstantValue;
        public StringVariable Variable;

        public StringReference(string value)
        {
            Mode = VariableReferenceType.Constant;
            ConstantValue = value;
        }

        public override string Value
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

        public static implicit operator string(StringReference reference)
        {
            return reference.Value;
        }
    }
}
