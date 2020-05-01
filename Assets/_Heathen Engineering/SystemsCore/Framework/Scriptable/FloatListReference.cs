using System;
using System.Collections.Generic;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class FloatListReference : VariableReference<List<float>>
    {
        public List<float> ConstantValue;
        public FloatListVariable Variable;

        public FloatListReference(List<float> value)
        {
            Mode = VariableReferenceType.Constant;
            ConstantValue = value;
        }

        public override List<float> Value
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

        public static implicit operator List<float>(FloatListReference reference)
        {
            return reference.Value;
        }
    }
}
