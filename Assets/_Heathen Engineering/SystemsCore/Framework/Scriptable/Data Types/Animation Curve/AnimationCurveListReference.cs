using System;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [Serializable]
    public class AnimationCurveListReference : VariableReference<List<AnimationCurve>>
    {
        public AnimationCurveListVariable Variable;
        public override IDataVariable<List<AnimationCurve>> m_variable => Variable;

        public AnimationCurveListReference(List<AnimationCurve> value) : base(value)
        { }
    }
}
