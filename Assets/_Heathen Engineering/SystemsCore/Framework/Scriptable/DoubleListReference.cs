using System;
using System.Collections.Generic;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class DoubleListReference : VariableReference<List<double>>
    {
        public List<double> ConstantValue;
        public DoubleListVariable Variable;

        public DoubleListReference(List<double> value)
        {
            Mode = VariableReferenceType.Constant;
            ConstantValue = value;
        }

        public override List<double> Value
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

        public static implicit operator List<double>(DoubleListReference reference)
        {
            return reference.Value;
        }
    }
}
