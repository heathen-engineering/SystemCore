using System;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class RectTransformReference : VariableReference<RectTransform>
    {
        public RectTransform ConstantValue;
        public RectTransformVariable Variable;

        public RectTransformReference(RectTransform value)
        {
            Mode = VariableReferenceType.Constant;
            ConstantValue = value;
        }

        public override RectTransform Value
        {
            get { return Mode != VariableReferenceType.Referenced || Variable == null ? ConstantValue : Variable.rectTransform; }
            set
            {
                if (Mode != VariableReferenceType.Static)
                {
                    if (Mode == VariableReferenceType.Referenced && Variable != null)
                        Variable.rectTransform = value;
                    else
                        ConstantValue = value;
                }
            }
        }

        public static implicit operator RectTransform(RectTransformReference reference)
        {
            return reference.Value;
        }
    }
}
