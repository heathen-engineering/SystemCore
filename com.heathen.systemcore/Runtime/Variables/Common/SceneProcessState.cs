#if HE_SYSCORE
using System;
using System.Collections.Generic;
using System.Text;
using UnityEditor;

namespace HeathenEngineering
{
    [Serializable]
    public class SceneProcessState
    {
        public int setActiveScene = -1;
        public List<int> unloadTargets;
        public List<int> loadTargets;
        public float unloadProgress;
        public float loadProgress;
        public float transitionProgress;
        public bool complete;
        public bool hasError;
        public string errorMessage;

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Loading [" + loadTargets.Count + "] scenes: " + loadProgress.ToString("P0") + " complete.\n");
            builder.Append("Unloading [" + unloadTargets.Count + "] scenes " + unloadProgress.ToString("P0") + " complete.\n");
            builder.Append("Total completion: " + transitionProgress.ToString("P0") + " complete.");
            return builder.ToString();
        }
    }
}
#endif