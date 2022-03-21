#if HE_SYSCORE
using HeathenEngineering.Serializable;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Application/Data Library")]
    public class DataLibraryVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public List<KeyedVariable> Library = new List<KeyedVariable>();
                
        /// <summary>
        /// Generates a new KeyedDataLibrary based on the defaults of the Variable library.
        /// </summary>
        /// <returns></returns>
        public KeyedDataLibrary CreateNewKeyedDataLibrary(bool applyDefaults)
        {
            KeyedDataLibrary n = new KeyedDataLibrary();
            foreach (var pair in Library)
            {
                n[pair.Key] = pair.Default.ObjectValue;
                if (applyDefaults)
                    pair.Variable.ObjectValue = pair.Default.ObjectValue;
            }
            return n;
        }

        /// <summary>
        /// Applys the default value to the variable value
        /// </summary>
        public void ApplyDefaults()
        {
            foreach (var pair in Library)
            {
                pair.Variable.ObjectValue = pair.Default.ObjectValue;
            }
        }

        public void SyncToFile(string path, bool createDirectory)
        {
            if (createDirectory)
                CreateDirectoryIfRequired(path);

            byte[] buffer;
            SyncToBuffer(out buffer);
            FileStream fs = new FileStream(path, FileMode.Create);
            fs.Write(buffer, 0, buffer.Length);
            fs.Close();
        }

        public void SyncToFilePath(string path)
        {
            SyncToFile(path, false);
        }

        public void SyncToFilePathWithCreate(string path)
        {
            SyncToFile(path, true);
        }

        public void SyncToReferenceFile(StringVariable path, bool createDirectory)
        {
            SyncToFile(path.Value, createDirectory);
        }

        public void SyncToReferencePath(StringVariable path)
        {
            SyncToFile(path.Value, false);
        }

        public void SyncToReferencePathWithCreate(StringVariable path)
        {
            SyncToFile(path.Value, true);
        }

        public void SyncToKeyedLibrary(KeyedDataLibrary keyedLibrary)
        {
            if (keyedLibrary != null)
            {
                foreach (var pair in Library)
                {
                    keyedLibrary[pair.Key] = pair.Variable.ObjectValue;
                }
            }
        }

        public void SyncToBuffer(out byte[] buffer)
        {
            KeyedDataLibrary keyedDataLibrary;
            keyedDataLibrary = new KeyedDataLibrary();
            SyncToKeyedLibrary(keyedDataLibrary);
            buffer = KeyedDataLibrary.Serialize(keyedDataLibrary);
        }

        public void SyncFromFile(string path)
        {
            SyncFromBuffer(File.ReadAllBytes(path));
        }

        public void SyncFromReferenceFile(StringVariable path)
        {
            SyncFromFile(path.Value);
        }

        public void SyncFromKeyedLibrary(KeyedDataLibrary keyedLibrary)
        {
            if (keyedLibrary != null)
            {
                foreach (var pair in Library)
                {
                    if (keyedLibrary.Contains(pair.Key))
                        pair.Variable.ObjectValue = keyedLibrary.GetValue(pair.Key);
                }
            }
        }

        public void CreateDirectoryIfRequired(string filePath)
        {
            string working = filePath.Replace("\\", "/");
            if (!File.Exists(working) && !Directory.Exists(working.Substring(0, working.LastIndexOf('/'))))
                Directory.CreateDirectory(filePath.Substring(0, working.LastIndexOf('/')));
        }

        public void CreateReferencedDirectoryIfRequired(StringVariable filePath)
        {
            CreateDirectoryIfRequired(filePath.Value);
        }

        public void SyncFromBuffer(byte[] buffer)
        {
            KeyedDataLibrary keyedDataLibrary;
            keyedDataLibrary = KeyedDataLibrary.Deserialize(buffer);
            SyncFromKeyedLibrary(keyedDataLibrary);
        }
    }
}
#endif