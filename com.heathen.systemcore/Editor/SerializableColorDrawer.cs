//No longer used


//#if HE_SYSCORE
//using HeathenEngineering.Serializable;
//using UnityEditor;
//using UnityEngine;

//namespace HeathenEngineering.Editors
//{
//    [CustomPropertyDrawer(typeof(float4))]
//    public class SerializableColorDrawer : PropertyDrawer
//    {
//        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//        {
//            EditorGUI.BeginProperty(position, label, property);
//            SerializedProperty x = property.FindPropertyRelative("x");
//            SerializedProperty y = property.FindPropertyRelative("y");
//            SerializedProperty z = property.FindPropertyRelative("z");
//            SerializedProperty w = property.FindPropertyRelative("w");

//            EditorGUI.BeginChangeCheck();
//            Color c = new Color(x.floatValue, y.floatValue, z.floatValue, w.floatValue);
//            c = EditorGUI.ColorField(position, label, c, true, true, true);
//            x.floatValue = c.r;
//            y.floatValue = c.g;
//            z.floatValue = c.b;
//            w.floatValue = c.a;

//            if (EditorGUI.EndChangeCheck())
//                property.serializedObject.ApplyModifiedProperties();

//            EditorGUI.EndProperty();
//        }
//    }
//}
//#endif