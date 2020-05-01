using System;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    /// <summary>
    /// <para>Can be used in place of camera to represent a Camera setting that can be defined in your project as a <see cref="CameraVariable"/></para>
    /// </summary>
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// <description>Show a CameraReference on your game object</description>
    /// <code>
    /// public class ExampleBehaviour : MonoBehaviour
    /// {
    ///    public CameraReference cameraValue;
    /// }
    /// </code>
    /// </item>
    /// </list>
    /// </example>
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
