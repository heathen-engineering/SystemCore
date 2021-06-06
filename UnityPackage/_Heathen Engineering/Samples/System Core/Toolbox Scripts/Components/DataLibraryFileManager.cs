using HeathenEngineering.Scriptable;
using HeathenEngineering.Serializable;
using System;
using System.ComponentModel;
using System.IO;
using UnityEngine;

namespace HeathenEngineering.Tools
{
    [AddComponentMenu("System Core/Save Data/Data Library File Manager")]
    public class DataLibraryFileManager : MonoBehaviour
    {
        public DataLibraryVariable ActiveDataLibrary;
        public StringReference TargetFilePath;
        public bool AsyncSaveIsRunning = false;
        public bool AsyncSaveHasError = false;

        private BackgroundWorker saveWorker;

        #region Convenance pass through
        public void SyncToFile(bool createDirectory)
        {
            ActiveDataLibrary.SyncToFile(TargetFilePath, createDirectory);
        }

        public void SyncToFile(string path)
        {
            ActiveDataLibrary.SyncToFile(path, false);
        }

        public void SyncToKeyedLibrary(KeyedDataLibrary keyedLibrary)
        {
            ActiveDataLibrary.SyncToKeyedLibrary(keyedLibrary);
        }

        public void SyncToBuffer(out byte[] buffer)
        {
            ActiveDataLibrary.SyncToBuffer(out buffer);
        }

        public void SyncFromFile()
        {
            ActiveDataLibrary.SyncFromFile(TargetFilePath);
        }

        public void SyncFromFile(string path)
        {
            ActiveDataLibrary.SyncFromFile(path);
        }

        public void SyncFromKeyedLibrary(KeyedDataLibrary keyedLibrary)
        {
            ActiveDataLibrary.SyncFromKeyedLibrary(keyedLibrary);
        }

        public void SyncFromBuffer(byte[] buffer)
        {
            ActiveDataLibrary.SyncFromBuffer(buffer);
        }

        public void ApplyDefaults()
        {
            ActiveDataLibrary.ApplyDefaults();
        }
        #endregion

        #region Background Options
        public void AsyncSyncToFile(bool CreateDirectory)
        {
            if(saveWorker != null && !saveWorker.IsBusy)
            {
                saveWorker.RunWorkerAsync(CreateDirectory);
            }
        }
        
        private void SaveWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                AsyncSaveIsRunning = true;
                AsyncSaveHasError = false;
                ConsoleLogger.Log("Save Started");
                if (ActiveDataLibrary != null && !string.IsNullOrEmpty(TargetFilePath.Value))
                {
                    ActiveDataLibrary.SyncToFile(TargetFilePath, (bool)e.Argument);
                    ConsoleLogger.Log("Save Complete: " + TargetFilePath.Value);
                }
                else
                {
                    AsyncSaveHasError = true;
                    ConsoleLogger.LogWarning("Save Aborted: Active Data Library and Target File Path must be populated before save.");
                }
            }
            catch (Exception ex)
            {
                AsyncSaveHasError = true;
                ConsoleLogger.LogError("Save Failed: " + ex.Message);
            }
        }
        
        private void SaveWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AsyncSaveIsRunning = false;
        }
        #endregion

        private void Start()
        {
            saveWorker = new BackgroundWorker();
            saveWorker.WorkerReportsProgress = true;
            saveWorker.WorkerSupportsCancellation = true;
            saveWorker.RunWorkerCompleted += SaveWorker_RunWorkerCompleted;
            saveWorker.DoWork += SaveWorker_DoWork;
        }

        private void OnDestroy()
        {
            if(saveWorker != null)
            {
                if (saveWorker.IsBusy)
                    saveWorker.CancelAsync();
            }
        }
    }
}
