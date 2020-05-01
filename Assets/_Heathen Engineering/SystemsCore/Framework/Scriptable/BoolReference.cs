using System;

namespace HeathenEngineering.Scriptable
{
    /// <summary>
    /// <para>Can be used in place of bool to represent an Boolean setting that can be defined in your project as a <see cref="BoolVariable"/></para>
    /// </summary>
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// <description>Show a BoolReference on your game object</description>
    /// <code>
    /// public class ExampleBehaviour : MonoBehaviour
    /// {
    ///    public BoolReference boolValue = new BoolReference(false);
    /// }
    /// </code>
    /// </item>
    /// </list>
    /// </example>
    [Serializable]
    public class BoolReference : VariableReference<bool>
    {
        public bool ConstantValue;
        public BoolVariable Variable;

        public BoolReference(bool value)
        {
            Mode = VariableReferenceType.Constant;
            ConstantValue = value;
        }

        public override bool Value
        {
            get { return Mode != VariableReferenceType.Referenced || Variable == null ? ConstantValue : Variable.Value; }
            set
            {
                if (Mode != VariableReferenceType.Static)
                {
                    if (Mode == VariableReferenceType.Referenced && Variable != null)
                        Variable.SetValue(value);
                    else
                        ConstantValue = value;
                }
            }
        }

        public static implicit operator bool(BoolReference reference)
        {
            return reference.Value;
        }

        public void ToggleValue()
        {
            Value = !Value;
        }
    }
}
