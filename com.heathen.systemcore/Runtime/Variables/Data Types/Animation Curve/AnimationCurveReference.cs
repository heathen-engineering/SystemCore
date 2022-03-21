#if HE_SYSCORE
using System;
using UnityEngine;

namespace HeathenEngineering
{
    [Serializable]
    public class AnimationCurveReference : VariableReference<AnimationCurve>
    {
        public AnimationCurveVariable Variable;
        public override IDataVariable<AnimationCurve> m_variable => Variable;

        public AnimationCurveReference(AnimationCurve value) : base(value)
        { }
    }
}
#endif