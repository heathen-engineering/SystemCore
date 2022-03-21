#if HE_SYSCORE
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Application/String Library")]
    public class StringLibrary : ScriptableObject
    {
        public string DisplayName;
        public string ISOCode;
        public Sprite Icon;
        
        public StringSet Data = new StringSet();

        public void Apply()
        {
            StringFieldManager.ApplyStringSet(Data);
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
            var oldList = new List<StringFieldValue>(Data.Values.ToArray());

            var fields = new List<StringField>();
            var paths = UnityEditor.AssetDatabase.FindAssets("t: StringField");
            foreach (var m in paths)
            {
                fields.Add(UnityEditor.AssetDatabase.LoadAssetAtPath<StringField>(UnityEditor.AssetDatabase.GUIDToAssetPath(m)));
            }

            fields.Sort((a, b) => { return a.Id.CompareTo(b.Id); });

            Data.Values.Clear();

            foreach (var field in fields)
            {
                var e = oldList.FirstOrDefault(p => p.Field == field);
                if (e != null)
                    Data.Values.Add(e);
                else
                {
                    var n = new StringFieldValue() { Field = field, value = field.defaultValue };
                    Data.Values.Add(n);
                }
            }
        }

        [ContextMenu("Test Serialize")]
        public void TestSerializeFile()
        {
            Debug.Log("Attempting to save to: " + DesignTimeFilePath + "/" + DisplayName + "_" + ISOCode + ".xml");
            SerializeLanguageSet(DesignTimeFilePath + "/" + DisplayName + "_" + ISOCode + ".xml");
        }

        [ContextMenu("Test Deserialize")]
        public void TestDeserializeFile()
        {
            Debug.Log("Attempting to read: " + DesignTimeFilePath + "/" + DisplayName + "_" + ISOCode + ".xml");
            DeserializeLanguageSet(DesignTimeFilePath + "/" + DisplayName + "_" + ISOCode + ".xml");
        }
#endif

        public void SerializeLanguageSet(string filePath)
        {
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(StringFieldDataModel));
            StringFieldDataModel n = new StringFieldDataModel();
            n.Name = DisplayName;
            n.Code = ISOCode;
            n.Records = new List<StringFieldRecord>();
            foreach (var r in Data.Values)
            {
                StringFieldRecord nr = new StringFieldRecord() { Id = r.Field.Id, Value = r.value };
                n.Records.Add(nr);
            }
            FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
            xmlSerializer.Serialize(fileStream, n);
            fileStream.Close();
            fileStream.Dispose();
        }

        public void DeserializeLanguageSet(string filePath)
        {
            if (File.Exists(filePath) && StringFieldManager.activeManager != null)
            {
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(StringFieldDataModel));
                FileStream fileStream = new FileStream(filePath, FileMode.Open);
                var data = xmlSerializer.Deserialize(fileStream) as StringFieldDataModel;
                fileStream.Close();
                fileStream.Dispose();

                DisplayName = data.Name;
                ISOCode = data.Code;

                var sortedFields = new List<StringField>(StringFieldManager.activeManager.availableFields);
                sortedFields.Sort((a, b) => { return a.Id.CompareTo(b.Id); });

                Data.Values.Clear();

                foreach (var field in sortedFields)
                {
                    var e = data.Records.FirstOrDefault(p => p.Id == field.Id);
                    if (e != null)
                        Data.Values.Add(new StringFieldValue() { Field = field, value = e.Value });
                    else
                    {
                        var n = new StringFieldValue() { Field = field, value = field.defaultValue };
                        Data.Values.Add(n);
                    }
                }
            }
            else
            {
                //TODO debug messages
                if (!File.Exists(filePath))
                    Debug.LogError("Unable to deserialize file [" + filePath + "] no such file exists.");

                if(StringFieldManager.activeManager == null)
                    Debug.LogError("Unable to deserialize file [" + filePath + "] there is no active String Field Manager.");
            }
        }

    }

}
#endif