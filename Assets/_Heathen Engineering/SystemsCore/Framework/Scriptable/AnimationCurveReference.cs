using System;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    /// <summary>
    /// <para>Can be used in place of AnimationCurve to represent an animation curve setting that can be defined in your project as a <see cref="AnimationCurveVariable"/></para>
    /// </summary>
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// <description>Show an AnimationCurveReference on your game object</description>
    /// <code>
    /// public class ExampleBehaviour : MonoBehaviour
    /// {
    ///    public AnimationCurveReference animationCurve = new AnimationCurveReference(AnimationCurve.Linear(0, 1, 1, 1));
    /// }
    /// </code>
    /// </item>
    /// </list>
    /// </example>
    [Serializable]
    public class AnimationCurveReference : VariableReference<AnimationCurve>
    {
        public AnimationCurve ConstantValue;
        public AnimationCurveVariable Variable;

        public AnimationCurveReference(AnimationCurve value)
        {
            Mode = VariableReferenceType.Constant;
            ConstantValue = value;
        }

        public override AnimationCurve Value
        {
            get { return Mode != VariableReferenceType.Referenced || Variable == null ? ConstantValue : Variable.curve; }
            set
            {
                if (Mode != VariableReferenceType.Static)
                {
                    if (Mode == VariableReferenceType.Referenced && Variable != null)
                        Variable.curve = value;
                    else
                        ConstantValue = value;
                }
            }
        }

        public float Evaluate(float time)
        {
            return Value.Evaluate(time);
        }

        public static implicit operator AnimationCurve(AnimationCurveReference reference)
        {
            return reference.Value;
        }
    }
}
