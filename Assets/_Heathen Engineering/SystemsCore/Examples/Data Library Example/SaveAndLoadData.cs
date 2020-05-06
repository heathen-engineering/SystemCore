using HeathenEngineering.Scriptable;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveAndLoadData : MonoBehaviour
{
    public string filePath = "./ Data Library Example/library.dat";
    public DataLibraryVariable library;

    [ContextMenu("Save")]
    public void Save()
    {
        library.SyncToFile(filePath, true);
        FileInfo newInfo = new FileInfo(filePath);
        Debug.Log("Saved file to [" + newInfo.FullName + "]");
    }

    [ContextMenu("Load")]
    public void Load()
    {
        FileInfo newInfo = new FileInfo(filePath);

        if (newInfo.Exists)
        {
            library.SyncFromFile(filePath);
            Debug.Log("Loaded file from [" + newInfo.FullName + "]");
        }
        else
        {
            Debug.Log("No file found.");
        }
    }
}
