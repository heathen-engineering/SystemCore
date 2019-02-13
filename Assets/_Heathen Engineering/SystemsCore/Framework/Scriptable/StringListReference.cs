using System;
using System.Collections.Generic;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class StringListReference : VariableReference<List<StringReference>>
    {
        public List<StringReference> ConstantValue;
        public StringListVariable Variable;

        public StringListReference(List<StringReference> value)
        {
            Mode = VariableReferenceType.Constant;
            ConstantValue = value;
        }

        public override List<StringReference> Value
        {
            get { return Mode != VariableReferenceType.Referenced || Variable == null ? ConstantValue : Variable.Values; }
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

        public static implicit operator List<StringReference>(StringListReference reference)
        {
            return reference.Value;
        }
    }
}
