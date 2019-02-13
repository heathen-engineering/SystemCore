using System;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class IntReference : VariableReference<int>
    {
        public int ConstantValue;
        public IntVariable Variable;

        public IntReference(int value)
        {
            Mode = VariableReferenceType.Constant;
            ConstantValue = value;
        }

        public override int Value
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

        public static implicit operator int(IntReference reference)
        {
            return reference.Value;
        }

        public void Incrament()
        {
            Value = Value + 1;
        }

        public void Decrament()
        {
            Value = Value - 1;
        }
    }
}
