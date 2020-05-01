using System;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class UnsignedLongReference : VariableReference<ulong>
    {
        public ulong ConstantValue;
        public UnsignedLongVariable Variable;

        public UnsignedLongReference(ulong value)
        {
            Mode = VariableReferenceType.Constant;
            ConstantValue = value;
        }

        public override ulong Value
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

        public static implicit operator ulong(UnsignedLongReference reference)
        {
            return reference.Value;
        }
    }
}
