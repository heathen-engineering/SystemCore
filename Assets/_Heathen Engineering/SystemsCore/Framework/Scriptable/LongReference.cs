using System;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class LongReference : VariableReference<long>
    {
        public long ConstantValue;
        public LongVariable Variable;

        public LongReference(long value)
        {
            Mode = VariableReferenceType.Constant;
            ConstantValue = value;
        }

        public override long Value
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

        public static implicit operator long(LongReference reference)
        {
            return reference.Value;
        }
    }
}
