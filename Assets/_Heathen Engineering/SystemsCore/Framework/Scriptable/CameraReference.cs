using System;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class CameraReference : VariableReference<Camera>
    {
        public Camera ConstantValue;
        public CameraVariable Variable;

        public CameraReference(Camera value)
        {
            Mode = VariableReferenceType.Constant;
            ConstantValue = value;
        }

        public override Camera Value
        {
            get { return Mode != VariableReferenceType.Referenced || Variable == null ? ConstantValue : Variable.camera; }
            set
            {
                if (Mode != VariableReferenceType.Static)
                {
                    if (Mode == VariableReferenceType.Referenced && Variable != null)
                        Variable.camera = value;
                    else
                        ConstantValue = value;
                }
            }
        }

        public static implicit operator Camera(CameraReference reference)
        {
            return reference.Value;
        }
    }
}
