//No longer used

//using HeathenEngineering.Serializable;
//using UnityEditor;
//using UnityEngine;

//namespace HeathenEngineering.Editors
//{
//    [CustomPropertyDrawer(typeof(SerializableVector4), true)]
//    public class SerializableVector4Drawer : PropertyDrawer
//    {
//        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//        {
//            EditorGUI.BeginProperty(position, label, property);
//            SerializedProperty x = property.FindPropertyRelative("x");
//            SerializedProperty y = property.FindPropertyRelative("y");
//            SerializedProperty z = property.FindPropertyRelative("z");
//            SerializedProperty w = property.FindPropertyRelative("w");

//            EditorGUI.BeginChangeCheck();
//            Vector4 c = new Vector4(x.floatValue, y.floatValue, z.floatValue, w.floatValue);
//            c = EditorGUI.Vector4Field(position, label, c);
//            x.floatValue = c.x;
//            y.floatValue = c.y;
//            z.floatValue = c.z;
//            w.floatValue = c.w;

//            if (EditorGUI.EndChangeCheck())
//                property.serializedObject.ApplyModifiedProperties();

//            EditorGUI.EndProperty();
//        }
//    }
//}
