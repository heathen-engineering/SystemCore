using System;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class FloatReference : VariableReference<float>
    {        
        public float ConstantValue;
        public FloatVariable Variable;
        
        public FloatReference(float value)
        {
            Mode = VariableReferenceType.Constant;
            ConstantValue = value;
        }

        public override float Value
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

        public static implicit operator float(FloatReference reference)
        {
            return reference.Value;
        }
    }
}
