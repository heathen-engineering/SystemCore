using System;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    /// <summary>
    /// <para>Can be used in place of canvas to represent an Canvas setting that can be defined in your project as a <see cref="CanvasVariable"/></para>
    /// </summary>
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// <description>Show a CanvasReference on your game object</description>
    /// <code>
    /// public class ExampleBehaviour : MonoBehaviour
    /// {
    ///    public CanvasReference canvasValue;
    /// }
    /// </code>
    /// </item>
    /// </list>
    /// </example>
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
