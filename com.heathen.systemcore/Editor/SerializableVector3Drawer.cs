//No longer used

//using HeathenEngineering.Serializable;
//using UnityEditor;
//using UnityEngine;

//namespace HeathenEngineering.Editors
//{
//    [CustomPropertyDrawer(typeof(SerializableVector3))]
//    public class SerializableVector3Drawer : PropertyDrawer
//    {
//        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//        {
//            EditorGUI.BeginProperty(position, label, property);
//            SerializedProperty x = property.FindPropertyRelative("x");
//            SerializedProperty y = property.FindPropertyRelative("y");
//            SerializedProperty z = property.FindPropertyRelative("z");

//            EditorGUI.BeginChangeCheck();
//            Vector3 c = new Vector3(x.floatValue, y.floatValue, z.floatValue);
//            c = EditorGUI.Vector3Field(position, label, c);
//            x.floatValue = c.x;
//            y.floatValue = c.y;
//            z.floatValue = c.z;

//            if (EditorGUI.EndChangeCheck())
//                property.serializedObject.ApplyModifiedProperties();

//            EditorGUI.EndProperty();
//        }
//    }
//}
