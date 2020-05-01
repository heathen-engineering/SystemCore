using System;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class UnsignedIntReference : VariableReference<uint>
    {
        public uint ConstantValue;
        public UnsignedIntVariable Variable;

        public UnsignedIntReference(uint value)
        {
            Mode = VariableReferenceType.Constant;
            ConstantValue = value;
        }

        public override uint Value
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

        public static implicit operator uint(UnsignedIntReference reference)
        {
            return reference.Value;
        }
    }
}
