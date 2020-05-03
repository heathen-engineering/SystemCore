using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace HeathenEngineering.Tools.Editors
{
    [CustomEditor(typeof(ComponentListRegister))]
    public class ComponentListerEditor : Editor
    {
        private ComponentListRegister lister;
        private SerializedProperty targetList;
        private SerializedProperty componenet;

        private GUIStyle popupStyle;

        private void OnEnable()
        {
            targetList = serializedObject.FindProperty("TargetList");
            componenet = serializedObject.FindProperty("SubjectComponent");
        }

        public override void OnInspectorGUI()
        {
            //EditorGUILayout.HelpBox("Componenet Lister will record the subject component to the target list on enabled and remove it from the list on disabled.", MessageType.Info);

            lister = target as ComponentListRegister;

            if (popupStyle == null)
            {
                popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
                popupStyle.imagePosition = ImagePosition.ImageOnly;
            }

            EditorGUILayout.PropertyField(targetList);

            GameObject go = lister.gameObject;
            List<Component> current = new List<Component>();
            
            foreach (Component com in go.GetComponents<Component>())
            {
                current.Add(com);
            }


            string[] popupOptions = new string[current.Count];
            for(int i = 0; i < current.Count; i++)
            {
                popupOptions[i] = current[i].GetType().Name;
            }
            serializedObject.Update();

            Rect position = new Rect();
            GUIContent label = EditorGUI.BeginProperty(position, new GUIContent("Subject Component"), componenet);
            position = EditorGUI.PrefixLabel(position, label);

            EditorGUI.BeginChangeCheck();
            // Calculate rect for configuration button
            Rect buttonRect = new Rect(position);
            buttonRect.yMin += popupStyle.margin.top;
            buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
            position.xMin = buttonRect.xMax;

            // Store old indent level and set it to 0, the PrefixLabel takes care of it
            int indexOf = current.IndexOf(lister.SubjectComponent);
            int newIndex = EditorGUILayout.Popup("Subject Component", indexOf, popupOptions);
            if (indexOf != newIndex)
            {
                lister.SubjectComponent = current[newIndex];
            }


            serializedObject.ApplyModifiedProperties();
        }
    }
}
