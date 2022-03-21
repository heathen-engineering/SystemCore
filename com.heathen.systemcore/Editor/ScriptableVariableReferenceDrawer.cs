#if HE_SYSCORE
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace HeathenEngineering.Editors
{
    [CustomPropertyDrawer(typeof(VariableReference),true)]
    public class ScriptableVariableReferenceDrawer : PropertyDrawer
    {
        /// <summary>
        /// Options to display in the popup to select constant or variable.
        /// </summary>
        private readonly string[] popupOptions =
            { "Use Constant", "Use Static", "Use Reference" };

        /// <summary> Cached style to use to draw the popup button. </summary>
        private GUIStyle popupStyle;
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty mode = property.FindPropertyRelative("Mode");
            SerializedProperty constantValue = property.FindPropertyRelative("m_constantValue");
            SerializedProperty variable = property.FindPropertyRelative("Variable");
            if (mode.enumValueIndex != 2)
            {
                if (constantValue.hasChildren
                    && !constantValue.type.StartsWith("Serializable")
                    && !constantValue.type.Contains("Camera"))
                    return EditorGUI.GetPropertyHeight(variable) + EditorGUI.GetPropertyHeight(constantValue);
                else
                    return EditorGUI.GetPropertyHeight(constantValue);
            }
            else
                return EditorGUI.GetPropertyHeight(variable);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (popupStyle == null)
            {
                popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
                popupStyle.imagePosition = ImagePosition.ImageOnly;
            }

            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            EditorGUI.BeginChangeCheck();

            // Get properties
            SerializedProperty mode = property.FindPropertyRelative("Mode");
            SerializedProperty constantValue = property.FindPropertyRelative("m_constantValue");
            SerializedProperty variable = property.FindPropertyRelative("Variable");
            

            if (mode.enumValueIndex != 2 
                && constantValue.isArray
                && constantValue.type != "string")
            {

                //position.yMin += EditorGUI.GetPropertyHeight(variable);
                //position.xMin = 60;
                // Calculate rect for configuration button
                Rect buttonRect = new Rect(position);
                buttonRect.yMin += popupStyle.margin.top;
                buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
                position.xMin = buttonRect.xMax;

                // Store old indent level and set it to 0, the PrefixLabel takes care of it
                int indent = EditorGUI.indentLevel;
                EditorGUI.indentLevel = 0;

                int result = EditorGUI.Popup(buttonRect, mode.enumValueIndex, popupOptions, popupStyle);
                mode.enumValueIndex = result;
                //EditorGUI.indentLevel = indent;
                EditorGUI.LabelField(position, "List Data");
                EditorGUI.indentLevel = 0;
                position.yMin += EditorGUI.GetPropertyHeight(variable);
                position.xMin = popupStyle.fixedWidth * 2;
                
                EditorGUI.PropertyField(position, constantValue,
                    new GUIContent("Values"), true);


                if (EditorGUI.EndChangeCheck())
                    property.serializedObject.ApplyModifiedProperties();
                
                EditorGUI.EndProperty();
            }
            else
            {
                // Calculate rect for configuration button
                Rect buttonRect = new Rect(position);
                buttonRect.yMin += popupStyle.margin.top;
                buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
                position.xMin = buttonRect.xMax;

                // Store old indent level and set it to 0, the PrefixLabel takes care of it
                int indent = EditorGUI.indentLevel;
                EditorGUI.indentLevel = 0;

                int result = EditorGUI.Popup(buttonRect, mode.enumValueIndex, popupOptions, popupStyle);

                mode.enumValueIndex = result;

                if (constantValue.hasChildren && mode.enumValueIndex != 2 && !constantValue.type.StartsWith("Serializable")
                    && !constantValue.type.Contains("Camera"))
                {
                    if (constantValue.type == "string")
                    {
                        EditorGUI.LabelField(position, "Direct Value");
                        EditorGUI.indentLevel = 0;
                        position.yMin += EditorGUI.GetPropertyHeight(variable);
                        position.xMin = popupStyle.fixedWidth;

                        EditorGUI.PropertyField(position,
                            mode.enumValueIndex != 2 ? constantValue : variable,
                            GUIContent.none, true);
                    }
                    else
                    {
                        EditorGUI.LabelField(position, constantValue.type);
                        EditorGUI.indentLevel = 0;
                        position.yMin += EditorGUI.GetPropertyHeight(variable);
                        position.xMin = popupStyle.fixedWidth * 2;

                        EditorGUI.PropertyField(position,
                            mode.enumValueIndex != 2 ? constantValue : variable,
                            new GUIContent("Value"), true);
                    }
                }
                else
                {
                    EditorGUI.PropertyField(position,
                        mode.enumValueIndex != 2 ? constantValue : variable,
                        GUIContent.none);
                }

                if (EditorGUI.EndChangeCheck())
                    property.serializedObject.ApplyModifiedProperties();

                EditorGUI.indentLevel = indent;
                EditorGUI.EndProperty();
            }
        }
    }
}
#endif