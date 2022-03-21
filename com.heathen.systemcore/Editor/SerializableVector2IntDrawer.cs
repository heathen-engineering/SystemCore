//No longer used

//using HeathenEngineering.Serializable;
//using UnityEditor;
//using UnityEngine;

//namespace HeathenEngineering.Editors
//{
//    [CustomPropertyDrawer(typeof(SerializableVector2Int))]
//    public class SerializableVector2IntDrawer : PropertyDrawer
//    {
//        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//        {
//            EditorGUI.BeginProperty(position, label, property);
//            SerializedProperty x = property.FindPropertyRelative("x");
//            SerializedProperty y = property.FindPropertyRelative("y");

//            EditorGUI.BeginChangeCheck();
//            Vector2Int c = new Vector2Int(x.intValue, y.intValue);
//            c = EditorGUI.Vector2IntField(position, label, c);
//            x.intValue = c.x;
//            y.intValue = c.y;

//            if (EditorGUI.EndChangeCheck())
//                property.serializedObject.ApplyModifiedProperties();

//            EditorGUI.EndProperty();
//        }
//    }
//}
