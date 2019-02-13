using System;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class AnimationCurveReference : VariableReference<AnimationCurve>
    {
        public AnimationCurve ConstantValue;
        public AnimationCurveVariable Variable;

        public AnimationCurveReference(AnimationCurve value)
        {
            Mode = VariableReferenceType.Constant;
            ConstantValue = value;
        }

        public override AnimationCurve Value
        {
            get { return Mode != VariableReferenceType.Referenced || Variable == null ? ConstantValue : Variable.curve; }
            set
            {
                if (Mode != VariableReferenceType.Static)
                {
                    if (Mode == VariableReferenceType.Referenced && Variable != null)
                        Variable.curve = value;
                    else
                        ConstantValue = value;
                }
            }
        }

        public float Evaluate(float time)
        {
            return Value.Evaluate(time);
        }

        public static implicit operator AnimationCurve(AnimationCurveReference reference)
        {
            return reference.Value;
        }
    }
}
