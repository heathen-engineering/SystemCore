using HeathenEngineering.Events;
using UnityEngine;

namespace HeathenEngineering.Tools
{
    public class SceneProcessStateHandler : MonoBehaviour
    {
        [Header("References")]
        #region Game Events
        public SceneProcessStateGameEvent Started;
        public SceneProcessStateGameEvent Updated;
        public SceneProcessStateGameEvent Completed;
        #endregion

        [Header("Events")]
        #region Unity Events
        public UnitySceneProcessStateEvent OnStarted;
        public UnitySceneProcessStateEvent OnUpdated;
        public UnitySceneProcessStateEvent OnCompleted;
        #endregion
    }
}
