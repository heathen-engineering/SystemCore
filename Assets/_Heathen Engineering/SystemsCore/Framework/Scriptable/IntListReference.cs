using System;
using System.Collections.Generic;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class IntListReference : VariableReference<List<int>>
    {
        public List<int> ConstantValue;
        public IntListVariable Variable;

        public IntListReference(List<int> value)
        {
            Mode = VariableReferenceType.Constant;
            ConstantValue = value;
        }

        public override List<int> Value
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

        public static implicit operator List<int>(IntListReference reference)
        {
            return reference.Value;
        }
    }
}
