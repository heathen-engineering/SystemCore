using HeathenEngineering.Serializable;
using System;
using System.Collections.Generic;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class RectTransformListReference : VariableReference<List<SerializableRectTransform>>
    {
        public RectTransformListVariable Variable;
        public override IDataVariable<List<SerializableRectTransform>> m_variable => Variable;

        public RectTransformListReference(List<SerializableRectTransform> value) : base(value)
        { }
    }
}
