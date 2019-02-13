using System;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class CanvasReference : VariableReference<Canvas>
    {
        public Canvas ConstantValue;
        public CanvasVariable Variable;

        public CanvasReference(Canvas value)
        {
            Mode = VariableReferenceType.Constant;
            ConstantValue = value;
        }

        public override Canvas Value
        {
            get { return Mode != VariableReferenceType.Referenced || Variable == null ? ConstantValue : Variable.canvas; }
            set
            {
                if (Mode != VariableReferenceType.Static)
                {
                    if (Mode == VariableReferenceType.Referenced && Variable != null)
                        Variable.canvas = value;
                    else
                        ConstantValue = value;
                }
            }
        }

        public static implicit operator Canvas(CanvasReference reference)
        {
            return reference.Value;
        }
    }
}
