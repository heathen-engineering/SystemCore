using System;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class TransformPointerReference : VariableReference<Transform>
    {
        public TransformPointerVariable Variable;

        public override IDataVariable<Transform> m_variable => Variable;

        public TransformPointerReference(Transform value) : base(value)
        { }
    }
}
