#if HE_SYSCORE
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Application/String Field Manager")]
    public class StringFieldManager : ScriptableObject
    {
        public static StringFieldManager activeManager;
        public static StringSet activeSet;
        public List<StringLibrary> availableSets = new List<StringLibrary>();
        [Tooltip("Use the context menu to populate this list with all fields.\n\nThis list is used by Library serialization at runtime, if its empty serialization (save and load from disk) will not work.")]
        public List<StringField> availableFields = new List<StringField>();

        [ContextMenu("Activate Manager")]
        public void Activate()
        {
            activeManager = this;
        }

        public static void ApplyStringSet(StringSet set)
        {
            activeSet = set;

            foreach (var f in set.Values)
                f.Field.Value = f.value;
        }

        public void applyStringSet(StringSet set)
        {
            ApplyStringSet(set);
        }

#if UNITY_EDITOR
        [Header("Editor Tools")]
        [Multiline(5)]
        public string DeveloperNotes;
        [Tooltip("This is only available in the editor.\n\nThis should be an existing folder path on your system and is where the 'Test Serialize' and 'Test Deserialize' context methods will read and write from.\nNote the full path is <DesignTimeFilePath>/<DisplayName>_<ISOCode>.xml")]
        public string DesignTimeFilePath = "<Enter an absolute folder path here>";

        [ContextMenu("Update String Fields")]
        public void UpdateFieldsList()
        {
            var Fields = new List<StringField>();
            var fields = UnityEditor.AssetDatabase.FindAssets("t: StringField");
            foreach (var m in fields)
            {
                Fields.Add(UnityEditor.AssetDatabase.LoadAssetAtPath<StringField>(UnityEditor.AssetDatabase.GUIDToAssetPath(m)));
            }

            Fields.Sort((a, b) => { return a.Id.CompareTo(b.Id); });

            availableFields = Fields;
        }

        [ContextMenu("Test Serialize")]
        public void TestSerializeFile()
        {
            foreach (var set in availableSets)
            {
                set.DesignTimeFilePath = DesignTimeFilePath;
                set.TestSerializeFile();
            }
        }

        [ContextMenu("Test Deserialize")]
        public void TestDeserializeFile()
        {
            foreach (var set in availableSets)
            {
                set.DesignTimeFilePath = DesignTimeFilePath;
                set.TestDeserializeFile();
            }
        }
#endif
    }
}
#endif