using System;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class BoolReference : VariableReference<bool>
    {
        public bool ConstantValue;
        public BoolVariable Variable;

        public BoolReference(bool value)
        {
            Mode = VariableReferenceType.Constant;
            ConstantValue = value;
        }

        public override bool Value
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

        public static implicit operator bool(BoolReference reference)
        {
            return reference.Value;
        }

        public void ToggleValue()
        {
            Value = !Value;
        }
    }
}
