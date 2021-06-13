using System;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class RectTransformPointerReference : VariableReference<RectTransform>
    {
        public RectTransformPointerVariable Variable;

        public override IDataVariable<RectTransform> m_variable => Variable;

        public RectTransformPointerReference(RectTransform value) : base(value)
        { }
    }
}
