using System;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class DoubleReference : VariableReference<double>
    {
        public double ConstantValue;
        public DoubleVariable Variable;

        public DoubleReference(double value)
        {
            Mode = VariableReferenceType.Constant;
            ConstantValue = value;
        }

        public override double Value
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

        public static implicit operator double(DoubleReference reference)
        {
            return reference.Value;
        }
    }
}
