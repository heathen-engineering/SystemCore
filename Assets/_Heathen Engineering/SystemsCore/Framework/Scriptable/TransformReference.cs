using System;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class TransformReference : VariableReference<Transform>
    {
        public Transform ConstantValue;
        public TransformVariable Variable;

        public TransformReference(Transform value)
        {
            Mode = VariableReferenceType.Constant;
            ConstantValue = value;
        }

        public override Transform Value
        {
            get { return Mode != VariableReferenceType.Referenced || Variable == null ? ConstantValue : Variable.transform; }
            set
            {
                if (Mode != VariableReferenceType.Static)
                {
                    if (Mode == VariableReferenceType.Referenced && Variable != null)
                        Variable.transform = value;
                    else
                        ConstantValue = value;
                }
            }
        }

        public static implicit operator Transform(TransformReference reference)
        {
            return reference.Value;
        }
    }
}
