using System;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class GameObjectReference : VariableReference<GameObject>
    {
        public GameObject ConstantValue;
        public GameObjectVariable Variable;

        public GameObjectReference(GameObject value)
        {
            Mode = VariableReferenceType.Constant;
            ConstantValue = value;
        }

        public override GameObject Value
        {
            get { return Mode != VariableReferenceType.Referenced || Variable == null ? ConstantValue : Variable.gameObject; }
            set
            {
                if (Mode != VariableReferenceType.Static)
                {
                    if (Mode == VariableReferenceType.Referenced && Variable != null)
                        Variable.gameObject = value;
                    else
                        ConstantValue = value;
                }
            }
        }

        public static implicit operator GameObject(GameObjectReference reference)
        {
            return reference.Value;
        }
    }
}
