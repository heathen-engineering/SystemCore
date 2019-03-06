using UnityEngine;
using HeathenEngineering.Scriptable;
using System;
using System.Collections.Generic;

namespace HeathenEngineering.Tools
{
    [RequireComponent(typeof(UnityEngine.UI.Text))]
    [AddComponentMenu("Heathen/Application/Unity Text String Field")]
    public class UnityTextStringField : MonoBehaviour
    {
        public StringField field;
        private UnityEngine.UI.Text textField;

        private void Awake()
        {
            textField = GetComponent<UnityEngine.UI.Text>();
        }

        private void OnEnable()
        {
            field.ValueChanged.AddListener(handleChange);
            textField.text = field.Value;
        }

        private void OnDisable()
        {
            field.ValueChanged.RemoveListener(handleChange);
        }

        private void handleChange(string arg0)
        {
            if (textField != null)
                textField.text = arg0;
        }

#if UNITY_EDITOR
        [ContextMenu("Find or Create String Field")]
        public void CreateTranslationField()
        {
            var tField = GetComponent<UnityEngine.UI.Text>();

            if (tField == null)
            {
                Debug.LogWarning("No text field found.");
            }
            else
            {

                var fields = new List<StringField>();
                var paths = UnityEditor.AssetDatabase.FindAssets("t: StringField");
                foreach (var m in paths)
                {
                    fields.Add(UnityEditor.AssetDatabase.LoadAssetAtPath<StringField>(UnityEditor.AssetDatabase.GUIDToAssetPath(m)));
                }

                fields.Sort((a, b) => { return a.Id.CompareTo(b.Id); });

                int maxId = -1;
                foreach (var f in fields)
                {
                    maxId = Mathf.Max(maxId, (int)f.Id);

                    if (f.defaultValue == tField.text)
                    {
                        field = f;
                        Debug.Log("Text Match Found");
                        return;
                    }
                }
                maxId++;
                Debug.Log("No Match Found, Creating New Entry!");
                var asset = ScriptableObject.CreateInstance<StringField>();
                asset.name = maxId.ToString() + " " + tField.gameObject.name;
                asset.defaultValue = tField.text;
                asset.Id = Convert.ToUInt32(maxId);

                if (!UnityEditor.AssetDatabase.IsValidFolder("Assets/String Fields"))
                    UnityEditor.AssetDatabase.CreateFolder("Assets", "String Fields");

                UnityEditor.AssetDatabase.CreateAsset(asset, "Assets/String Fields/" + asset.name + ".asset");
                var nr = UnityEditor.AssetDatabase.LoadAssetAtPath<StringField>("Assets/String Fields/" + asset.name + ".asset");
                field = nr;
            }
        }
#endif
    }
}
