using HeathenEngineering.Events;
using HeathenEngineering.Scriptable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace HeathenEngineering.Tools
{
    /// <summary>
    /// Manages the multi-scene structure of your game.
    /// </summary>
    /// <remarks>
    /// This must be placed in your "0 bootstrap.scene"
    /// </remarks>
    public class ScenesManager : MonoBehaviour
    {
        public bool LoadEntryOnStartup = false;

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

        /// <summary>
        /// Returns true when the bootstrap scene (build index 0) is loaded
        /// </summary>
        public bool isBootstrapLoaded
        {
            get
            {
                var scene = SceneManager.GetSceneByBuildIndex(0);
                return scene.IsValid() && scene.isLoaded;
            }
        }

        /// <summary>
        /// Returns true when the entry scene (build index 1) is loaded
        /// </summary>
        public bool isEntryLoaded
        {
            get
            {
                var scene = SceneManager.GetSceneByBuildIndex(1);
                return scene.IsValid() && scene.isLoaded;
            }
        }

        /// <summary>
        /// Scene reference for the bootstrap scene (scene at build index 0)
        /// </summary>
        public Scene Bootstrap
        {
            get
            {
                return SceneManager.GetSceneByBuildIndex(0);
            }
        }

        /// <summary>
        /// Scene reference for the entry scene (scene at build index 1)
        /// </summary>
        public Scene Entry
        {
            get
            {
                return SceneManager.GetSceneByBuildIndex(1);
            }
        }

        /// <summary>
        /// Creates a list reference of all the scenes that are currently loaded.
        /// </summary>
        public List<Scene> LoadedScenes
        {
            get
            {
                return Scenes.Loaded;
            }
        }

        void Start()
        {
            if (Scenes.manager != null)
            {
                Debug.LogWarning("Detected multiple ScenesManagers ... this is not supported please insure that 1 and only 1 ScenesManger exists and that it is loaded at the start and never reloaded or unloaded.");
            }

            Scenes.manager = this;

            if (LoadEntryOnStartup)
                ReturnToEntry();
        }

        /// <summary>
        /// Loads the entry scene (build index 1) if required and unloads all other scenes (except bootstrap [build index 0])
        /// </summary>
        public void ReturnToEntry()
        {
            ReturnToEntry(null);
        }

        /// <summary>
        /// Loads the entry scene (build index 1) if required and unloads all other scenes (except bootstrap [build index 0])
        /// </summary>
        /// <param name="action">Called when the process is completed.</param>
        public void ReturnToEntry(UnityAction<SceneProcessState> action)
        {
            if (isEntryLoaded)
            {
                Debug.LogWarning("Attempt to load menu scene (" + Entry.name + ") while its already loaded.\nNo actions taken!");
                return;
            }

            SceneProcessState nState = new SceneProcessState();
            nState.setActiveScene = 1;
            nState.unloadTargets = new List<int>();
            nState.loadTargets = new List<int>();
            var loadedScenes = SceneManager.sceneCount;
            for (int i = 0; i < loadedScenes; i++)
            {
                var scene = SceneManager.GetSceneAt(i);

                if (scene.isLoaded && scene.buildIndex != 0)
                {
                    nState.unloadTargets.Add(scene.buildIndex);
                }
            }

            nState.loadTargets.Add(1);

            StartCoroutine(ProcessState(nState, action));
        }

        /// <summary>
        /// Loads one scene while unloading another raising started, updated and completed events as required. 
        /// </summary>
        /// <param name="from">The scene to transition from, this will be unloaded</param>
        /// <param name="to">The scene to transition to, this will be loaded</param>
        /// <param name="setToAsActive">If true the "to" scene will be set as the active scene</param>
        public void Transition(int from, int to, bool setToAsActive)
        {
            Transition(new int[] { from }, new int[] { to }, setToAsActive ? to : -1, null);
        }

        /// <summary>
        /// Loads one scene while unloading another raising started, updated and completed events as required. 
        /// </summary>
        /// <param name="from">The scenes to transition from, this will be unloaded</param>
        /// <param name="to">The scenes to transition to, this will be loaded</param>
        ///<param name="activeScene">The scene to set as the active scene</param>
        public void Transition(IEnumerable<int> from, IEnumerable<int> to, int activeScene)
        {
            Transition(from, to, activeScene, null);
        }

        /// <summary>
        /// Loads one scene while unloading another raising started, updated and completed events as required. 
        /// </summary>
        /// <param name="from">The scene to transition from, this will be unloaded</param>
        /// <param name="to">The scene to transition to, this will be loaded</param>
        /// <param name="setToAsActive">If true the "to" scene will be set as the active scene</param>
        /// <param name="action">Called when the process completes</param>
        public void Transition(int from, int to, bool setToAsActive, UnityAction<SceneProcessState> action)
        {
            Transition(new int[] { from }, new int[] { to }, setToAsActive ? to : -1, action);
        }

        /// <summary>
        /// Loads one scene while unloading another raising started, updated and completed events as required. 
        /// </summary>
        /// <param name="from">The scenes to transition from, this will be unloaded</param>
        /// <param name="to">The scenes to transition to, this will be loaded</param>
        /// <param name="action">Called when the process completes</param>
        public void Transition(IEnumerable<int> from, IEnumerable<int> to, UnityAction<SceneProcessState> action)
        {
            Transition(from, to, -1, action);
        }

        /// <summary>
        /// Loads one scene while unloading another raising started, updated and completed events as required. 
        /// </summary>
        /// <param name="from">The scenes to transition from, this will be unloaded</param>
        /// <param name="to">The scenes to transition to, this will be loaded</param>
        ///<param name="activeScene">The scene to set as thee active scene</param>
        /// <param name="action">Called when the process completes</param>
        public void Transition(IEnumerable<int> from, IEnumerable<int> to, int activeScene, UnityAction<SceneProcessState> action)
        {
            SceneProcessState nState = new SceneProcessState()
            {
                loadTargets = new List<int>(to),
                unloadTargets = new List<int>(from),
                setActiveScene = activeScene
            };

            StartCoroutine(ProcessState(nState, action));
        }

        /// <summary>
        /// Loads a given scene optionally setting it as the active scene
        /// </summary>
        /// <param name="scene">The build index of the scene to load</param>
        /// <param name="setActive">Should this scene be set active when loaded</param>
        public void Load(int scene, bool setActive)
        {
            Load(new int[] { scene }, (setActive ? scene : -1), null);
        }

        /// <summary>
        /// Loads multiple scenes setting one as active when complete
        /// </summary>
        /// <param name="scenes">The scens to load</param>
        /// <param name="activeScene">The scene to set active, -1 indicates that no scene should be set active, this will leave active scene up to Unity</param>
        public void Load(IEnumerable<int> scenes, int activeScene)
        {
            Load(scenes, activeScene, null);
        }

        /// <summary>
        /// Loads a scene and optioanlly sets it as active
        /// </summary>
        /// <param name="scene">The build index of the scene to load</param>
        /// <param name="setActive">Should the scene be set active when loaded</param>
        /// <param name="action">This is called when the process completes</param>
        public void Load(int scene, bool setActive, UnityAction<SceneProcessState> action)
        {
            Load(new int[] { scene }, (setActive ? scene : -1), action);
        }

        /// <summary>
        /// Loads multiple scenes optionally setting one as active and calling an action when complete
        /// </summary>
        /// <param name="scenes">The scenes to load</param>
        /// <param name="activeScene">The scene to set active ... if -1 no scene will be set active</param>
        /// <param name="action">The action to call when the process is complete</param>
        public void Load(IEnumerable<int> scenes, int activeScene, UnityAction<SceneProcessState> action)
        {
            var nState = new SceneProcessState()
            {
                unloadTargets = new List<int>(),
                loadTargets = new List<int>(scenes),
                setActiveScene = activeScene,
            };

            StartCoroutine(ProcessState(nState, action));
        }

        /// <summary>
        /// Unload the indicated scene if its loaded
        /// </summary>
        /// <param name="scene">The scene to unload</param>
        public void Unload(int scene)
        {
            Unload(new int[] { scene }, null);
        }

        /// <summary>
        /// Unload the indicated scenes if they are loaded.
        /// </summary>
        /// <param name="scenes">The scenes to unload</param>
        public void Unload(IEnumerable<int> scenes)
        {
            Unload(scenes, null);
        }

        /// <summary>
        /// Unloads the indicated scene and calls the indicated action when complete
        /// </summary>
        /// <param name="scene">The scene to unload</param>
        /// <param name="action">This is called when the process is complete</param>
        public void Unload(int scene, UnityAction<SceneProcessState> action)
        {
            Unload(new int[] { scene }, action);
        }

        /// <summary>
        /// Unloads multiple scenes if they are loaded and calls the indicated action when the process is complete
        /// </summary>
        /// <param name="scenes">The scenes to be unloaded</param>
        /// <param name="action">The action to call when complete</param>
        public void Unload(IEnumerable<int> scenes, UnityAction<SceneProcessState> action)
        {
            var nState = new SceneProcessState()
            {
                unloadTargets = new List<int>(),
                loadTargets = new List<int>(scenes),
                setActiveScene = -1,
            };

            StartCoroutine(ProcessState(nState, action));
        }

        /// <summary>
        /// Sets the indicated scene as active if its loaded.
        /// </summary>
        /// <param name="buildIndex">The build index of the scene to set active</param>
        public void SetSceneActive(int buildIndex)
        {
            Scenes.SetSceneActive(buildIndex);
        }

        private IEnumerator ProcessState(SceneProcessState state, UnityAction<SceneProcessState> action)
        {
            if (Started != null)
                Started.Raise(this, state);

            OnStarted.Invoke(state);

            yield return new WaitForEndOfFrame();

            List<AsyncOperation> loadOperations = new List<AsyncOperation>();
            List<AsyncOperation> unloadOperations = new List<AsyncOperation>();

            if (state.loadTargets != null)
            {
                foreach (var scene in state.loadTargets)
                {
                    if (!Scenes.IsSceneLoaded(scene))
                    {
                        var op = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
                        op.allowSceneActivation = true;
                        loadOperations.Add(op);
                    }
                }
            }

            if (state.unloadTargets != null)
            {
                foreach (var scene in state.unloadTargets)
                {
                    var op = SceneManager.UnloadSceneAsync(scene);
                    op.allowSceneActivation = true;
                    unloadOperations.Add(op);
                }
            }

            int loadCount = loadOperations.Count;
            int unloadCount = unloadOperations.Count;

            while (loadOperations.Count > 0 || unloadOperations.Count > 0)
            {
                loadOperations.RemoveAll(p => p.isDone);
                unloadOperations.RemoveAll(p => p.isDone);

                float loadProgress = loadCount - loadOperations.Count;
                float unloadProgress = unloadCount - unloadOperations.Count;

                foreach (var op in loadOperations)
                {
                    loadProgress += op.progress;
                }

                foreach (var op in unloadOperations)
                {
                    unloadProgress += op.progress;
                }

                if (loadCount > 0)
                    loadProgress = loadProgress / loadCount;
                else
                    loadProgress = 1f;

                if (unloadCount > 0)
                    unloadProgress = unloadProgress / unloadCount;
                else
                    unloadProgress = 1f;

                state.loadProgress = loadProgress;
                state.unloadProgress = unloadProgress;
                if (loadCount > 0 && unloadCount > 0)
                    state.transitionProgress = (loadProgress + unloadProgress) / 2f;
                else if (loadCount > 0)
                    state.transitionProgress = loadProgress;
                else
                    state.transitionProgress = unloadProgress;

                if (Updated != null)
                    Updated.Raise(this, state);

                OnUpdated.Invoke(state);

                yield return new WaitForEndOfFrame();
            }

            SetSceneActive(state.setActiveScene);

            if (Completed != null)
                Completed.Raise(this, state);

            OnCompleted.Invoke(state);

            if (action != null)
                action.Invoke(state);
        }
    }
}
