#if HE_SYSCORE
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace HeathenEngineering.Editors
{
    public class StringLibraryEditor : EditorWindow 
    {
        List<StringFieldManager> Managers = new List<StringFieldManager>();
        List<StringLibrary> Libraries = new List<StringLibrary>();
        List<StringField> Fields = new List<StringField>();

        int selectedManager = 0;
        int selectedLib = 0;
        List<string> managerNames = new List<string>();
        List<string> libNames = new List<string>();
        List<string> fieldNames = new List<string>();
        List<string> currentManagersLibNames = new List<string>();

        string newManagerName;
        string newLangaugeName;
        string newLangageISO;

        Vector2 scrollPos;

        [MenuItem("Window/Heathen Engineering/Application Language Editor")]
        public static void ShowWindow()
        {
            GetWindow<StringLibraryEditor>("Application Language Editor");
        }

        private void OnGUI()
        {
            findData();
            drawUtilityButtons();
            if(drawHeader())
            {
                drawGrid();
            }
        }

        void drawGrid()
        {
            var m = Managers[selectedManager];

            if (m == null)
                return;

            var s = m.availableSets[selectedLib];

            if (s == null)
                return;

            EditorGUILayout.LabelField("Library Field Values", EditorStyles.boldLabel);

            EditorGUILayout.BeginHorizontal();
            var w = EditorGUIUtility.currentViewWidth;
            w -= 280;
            EditorGUILayout.LabelField("ID", GUILayout.Width(50));
            EditorGUILayout.LabelField("Field Name", GUILayout.Width(200));
            EditorGUILayout.LabelField("Default Value", GUILayout.Width((w / 2f) - 5));
            EditorGUILayout.LabelField("Translated Value", GUILayout.Width((w / 2f) - 5));
            EditorGUILayout.EndHorizontal();

            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, EditorStyles.helpBox);

            foreach(var f in Fields)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(f.Id.ToString(), GUILayout.Width(50));
                EditorGUILayout.LabelField(f.name.ToString(), GUILayout.Width(200));
                var o = f.defaultValue;
                f.defaultValue = EditorGUILayout.TextArea(f.defaultValue, GUILayout.Width((w / 2f) - 5));
                if (o != f.defaultValue)
                    EditorUtility.SetDirty(f);

                var fv = s.Data.Values.FirstOrDefault(p => p.Field == f);
                if(fv != null)
                {
                    o = fv.value;
                    fv.value = EditorGUILayout.TextArea(fv.value, GUILayout.Width((w / 2f) - 5));
                    if (fv.value != o)
                        EditorUtility.SetDirty(s);
                }
                else
                {
                    if(GUILayout.Button("Add Missing Field"))
                    {
                        s.Data.Values.Add(new StringFieldValue() { Field = f, value = f.Value });
                        EditorUtility.SetDirty(s);
                    }
                }
                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.EndScrollView();
        }

        void drawUtilityButtons()
        {
            EditorGUILayout.Space();
            EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);
            EditorGUILayout.BeginVertical(GUILayout.Width(300));
            EditorGUILayout.HelpBox("Assess all managers and libraries and insures all libraries and fields are properly referenced.", MessageType.None, true);
            if (GUILayout.Button("Baseline All", EditorStyles.toolbarButton))
            {
                fullAssesment();
            }
            EditorGUILayout.EndVertical();
            EditorGUILayout.BeginVertical(GUILayout.Width(300));
            EditorGUILayout.HelpBox("Assess the selected manager and its libraries and insures all libraries and fields are properly referenced.", MessageType.None, true);
            if (GUILayout.Button("Baseline Manager", EditorStyles.toolbarButton))
            {
                managerAssesment();
            }
            EditorGUILayout.EndVertical();
            EditorGUILayout.BeginVertical(GUILayout.Width(300));
            EditorGUILayout.HelpBox("Assess the selected library and insures all fields are properly referenced.", MessageType.None, true);
            if (GUILayout.Button("Baseline Library", EditorStyles.toolbarButton))
            {
                libraryAssement();
            }
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();
        }

        bool drawHeader()
        {
            EditorGUILayout.Space();

            if(Managers.Count < 1)
            {
                EditorGUILayout.HelpBox("No String Field Managers where found ...\nYou must first create at least 1 String Field Manager", MessageType.None, true);

                newManagerName = EditorGUILayout.TextField("New Manager Name", newManagerName);
                if(!string.IsNullOrEmpty(newManagerName))
                if(GUILayout.Button("Create String Field Manager", EditorStyles.toolbarButton))
                {
                    createNewManager(newManagerName);
                        newManagerName = string.Empty;
                }

                return false;
            }
            
            EditorGUILayout.LabelField("Select the Manager and Library you wish to edit then use the tools provided to populate the field values.", EditorStyles.boldLabel);
            EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);
            EditorGUILayout.BeginVertical(GUILayout.Width(350));
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            selectedManager = EditorGUILayout.Popup("Manager", selectedManager, managerNames.ToArray());
            EditorGUILayout.EndVertical();
            EditorGUILayout.BeginVertical();
            EditorGUILayout.HelpBox("Currently tracking " + Managers[selectedManager].availableFields.Count.ToString() + " of " + Fields.Count.ToString() + " fields\nand " + Managers[selectedManager].availableSets.Count.ToString() + " of " + Libraries.Count.ToString() + " Libraries in this manager.", MessageType.None, true);
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);
            EditorGUILayout.BeginVertical(GUILayout.Width(350));
            currentManagersLibNames.Clear();

            int c = Managers[selectedManager].availableSets.Count;
            Managers[selectedManager].availableSets.RemoveAll(p => p == null);

            if (c != Managers[selectedManager].availableSets.Count)
                EditorUtility.SetDirty(Managers[selectedManager]);

            foreach (var l in Managers[selectedManager].availableSets)
            {
                if (l != null)
                    currentManagersLibNames.Add(l.name);
            }

            if (currentManagersLibNames.Count < libNames.Count)
            {
                EditorGUILayout.HelpBox("This manager is not tracking all available libraries.", MessageType.None, true);
            }
            else
            {
                EditorGUILayout.HelpBox("This manager appears to be tracking all available libraries.", MessageType.None, true);
            }
            if (GUILayout.Button("Refresh Libraries", EditorStyles.toolbarButton))
            {
                addLibsToSelectedManager();
            }
            selectedLib = EditorGUILayout.Popup("Library", selectedLib, currentManagersLibNames.ToArray());
            EditorGUILayout.EndVertical();
            EditorGUILayout.Space();
            EditorGUILayout.BeginVertical();
            newLangaugeName = EditorGUILayout.TextField("Language Name", newLangaugeName);
            newLangageISO = EditorGUILayout.TextField("ISO Code", newLangageISO);
            EditorGUILayout.BeginHorizontal(GUILayout.Width(350));
            if (GUILayout.Button("Create New Library", EditorStyles.toolbarButton) && !string.IsNullOrEmpty(newLangaugeName))
            {
                createNewLibrary(newLangaugeName, newLangaugeName, newLangageISO);
                newLangaugeName = string.Empty;
                newLangageISO = string.Empty;
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();

            if (Managers[selectedManager].availableSets.Count < 1)
                return false;
            else
                return true;
        }

        void createNewManager(string displayName)
        {
            var asset = ScriptableObject.CreateInstance<StringFieldManager>();
            asset.name = displayName;
            asset.availableFields = new List<StringField>();
            if (Fields.Count > 0)
                asset.availableFields.AddRange(Fields.ToArray());
            asset.availableSets = new List<StringLibrary>();
            if (Libraries.Count > 0)
                asset.availableSets.AddRange(Libraries.ToArray());

            asset.DeveloperNotes = "Created in the Application Language Editor";

            if (!AssetDatabase.IsValidFolder("Assets/String Field Managers"))
                AssetDatabase.CreateFolder("Assets", "String Field Managers");

            string targetPath = "Assets/String Field Managers/" + asset.name + ".asset";
            targetPath = AssetDatabase.GenerateUniqueAssetPath(targetPath);
            AssetDatabase.CreateAsset(asset, targetPath);
            var nr = AssetDatabase.LoadAssetAtPath<StringFieldManager>(targetPath);
            Managers.Add(nr);
            managerNames.Add(nr.name);
        }

        void createNewLibrary(string displayName, string LanguageName, string ISOCode)
        {
            var asset = ScriptableObject.CreateInstance<StringLibrary>();
            asset.name = displayName;
            asset.Data = new StringSet();
            asset.Data.Values = new List<StringFieldValue>();
            asset.DisplayName = LanguageName;
            asset.ISOCode = ISOCode;

            foreach(var f in Fields)
            {
                asset.Data.Values.Add(new StringFieldValue() { Field = f, value = f.defaultValue });
            }

            asset.DeveloperNotes = "Created in the Application Language Editor";

            if (!AssetDatabase.IsValidFolder("Assets/String Libraries"))
                AssetDatabase.CreateFolder("Assets", "String Libraries");

            string targetPath = "Assets/String Libraries/" + asset.name + ".asset";
            targetPath = AssetDatabase.GenerateUniqueAssetPath(targetPath);
            AssetDatabase.CreateAsset(asset, targetPath);
            var nr = AssetDatabase.LoadAssetAtPath<StringLibrary>(targetPath);
            Libraries.Add(nr);
            libNames.Add(nr.name);

            var m = Managers[selectedManager];
            m.availableSets.Add(nr);
            EditorUtility.SetDirty(m);
        }

        void addLibsToSelectedManager()
        {
            var m = Managers[selectedManager];
            m.availableSets.Clear();
            if (Libraries.Count > 0)
                m.availableSets.AddRange(Libraries.ToArray());

            EditorUtility.SetDirty(m);
        }

        void findData()
        {
            Managers.Clear();
            managerNames.Clear();
            var fieldManagers = AssetDatabase.FindAssets("t: StringFieldManager");
            foreach(var m in fieldManagers)
            {
                var n = AssetDatabase.LoadAssetAtPath<StringFieldManager>(AssetDatabase.GUIDToAssetPath(m));
                Managers.Add(n);
                managerNames.Add(n.name);
            }

            Libraries.Clear();
            libNames.Clear();
            var libs = AssetDatabase.FindAssets("t: StringLibrary");
            foreach (var m in libs)
            {
                var n = AssetDatabase.LoadAssetAtPath<StringLibrary>(AssetDatabase.GUIDToAssetPath(m));
                Libraries.Add(n);
                libNames.Add(n.name);
            }

            Fields.Clear();
            fieldNames.Clear();
            var fields = AssetDatabase.FindAssets("t: StringField");
            foreach (var m in fields)
            {
                var n = AssetDatabase.LoadAssetAtPath<StringField>(AssetDatabase.GUIDToAssetPath(m));
                Fields.Add(n);
                fieldNames.Add(n.name);
            }
        }

        void fieldAssesment()
        {
            Dictionary<uint, StringField> fields = new Dictionary<uint, StringField>();
            foreach(var f in Fields)
            {
                if(fields.ContainsKey(f.Id))
                {
                    uint i = 0;
                    foreach(var p in fields)
                    {
                        i = (uint)Mathf.Max((int)p.Key, (int)i);
                    }
                    i++;
                    f.Id = i;
                    EditorUtility.SetDirty(f);
                    fields.Add(f.Id, f);
                }
                else
                {
                    fields.Add(f.Id, f);
                }
            }
        }

        void libraryAssement()
        {
            fieldAssesment();

            if (Managers.Count < 1)
                return;

            if (Libraries.Count < 1)
                return;

            var m = Managers[selectedManager];
            var s = m.availableSets[selectedLib];

            var oldFields = new List<StringFieldValue>(s.Data.Values);
            s.Data.Values.Clear();

            foreach (var f in Fields)
            {
                var t = oldFields.FirstOrDefault(p => p.Field.Id == f.Id);
                if (t != null)
                    s.Data.Values.Add(t);
                else
                {
                    s.Data.Values.Add(new StringFieldValue() { Field = f, value = f.defaultValue });
                }
            }

            EditorUtility.SetDirty(s);
        }

        void managerAssesment()
        {
            fieldAssesment();

            if (Managers.Count < 1)
                return;

            var m = Managers[selectedManager];
            m.availableSets.Clear();
            m.availableFields.Clear();
            m.availableSets.AddRange(Libraries.ToArray());
            m.availableFields.AddRange(Fields.ToArray());

            EditorUtility.SetDirty(m);
        }

        void fullAssesment()
        {
            fieldAssesment();

            if (Managers.Count < 1)
                createNewManager("Default String Field Manager");

            if (Libraries.Count < 1)
                createNewLibrary("Default Library", "English", "en");

            foreach(var m in Managers)
            {
                m.availableSets.Clear();
                m.availableFields.Clear();
                m.availableSets.AddRange(Libraries.ToArray());
                m.availableFields.AddRange(Fields.ToArray());

                EditorUtility.SetDirty(m);
            }

            foreach(var s in Libraries)
            {
                var oldFields = new List<StringFieldValue>(s.Data.Values);
                s.Data.Values.Clear();

                foreach(var f in Fields)
                {
                    var t = oldFields.FirstOrDefault(p => p.Field == f);
                    if (t != null)
                        s.Data.Values.Add(t);
                    else
                    {
                        s.Data.Values.Add(new StringFieldValue() { Field = f, value = f.defaultValue });
                    }
                }

                EditorUtility.SetDirty(s);
            }
        }
    }
}
#endif