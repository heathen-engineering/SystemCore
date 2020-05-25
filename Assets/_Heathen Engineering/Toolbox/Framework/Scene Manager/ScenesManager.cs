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
    /// This must be placed in your main.scene and on start will load your menu.scene additivly and asynchroniously
    /// </remarks>
    public class ScenesManager : MonoBehaviour
    {
        #region Game Events
        public SceneProcessStateGameEvent Started; 
        public SceneProcessStateGameEvent Updated;
        public SceneProcessStateGameEvent Completed;
        #endregion

        #region Unity Events
        public UnitySceneProcessStateEvent OnStarted;
        public UnitySceneProcessStateEvent OnUpdated;
        public UnitySceneProcessStateEvent OnCompleted;
        #endregion

        public bool isMainLoaded
        {
            get
            {
                var scene = SceneManager.GetSceneByBuildIndex(0);
                return scene.IsValid() && scene.isLoaded;
            }
        }

        public bool isMenuLoaded
        {
            get
            {
                var scene = SceneManager.GetSceneByBuildIndex(1);
                return scene.IsValid() && scene.isLoaded;
            }
        }

        public Scene Main
        {
            get
            {
                return SceneManager.GetSceneByBuildIndex(0);
            }
        }

        public Scene Menu
        {
            get
            {
                return SceneManager.GetSceneByBuildIndex(1);
            }
        }

        public List<Scene> LoadedScenes
        {
            get
            {
                return Scenes.Loaded;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            if (Scenes.manager != null)
            {
                Debug.LogWarning("Detected multiple ScenesManagers ... this is not supported please insure that 1 and only 1 ScenesManger exists and that it is loaded at the start and never reloaded or unloaded.");
            }

            Scenes.manager = this;
            ReturnToMenu();
        }

        public void ReturnToMenu()
        {
            ReturnToMenu(null);
        }

        public void ReturnToMenu(UnityAction<SceneProcessState> action)
        {
            if (isMenuLoaded)
            {
                Debug.LogWarning("Attempt to load menu scene (" + Menu.name + ") while its already loaded.\nNo actions taken!");
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

        public void Transition(int from, int to, bool setToAsActive)
        {
            Transition(new int[] { from }, new int[] { to }, setToAsActive ? to : -1, null);
        }

        public void Transition(IEnumerable<int> from, IEnumerable<int> to, int activeScene)
        {
            Transition(from, to, activeScene, null);
        }

        public void Transition(int from, int to, bool setToAsActive, UnityAction<SceneProcessState> action)
        {
            Transition(new int[] { from }, new int[] { to }, setToAsActive ? to : -1, action);
        }

        public void Transition(IEnumerable<int> from, IEnumerable<int> to, UnityAction<SceneProcessState> action)
        {
            Transition(from, to, -1, action);
        }

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

        public void Load(int scene, bool setActive)
        {
            Load(new int[] { scene }, (setActive ? scene : -1), null);
        }

        public void Load(IEnumerable<int> scene, int activeScene)
        {
            Load(scene, activeScene, null);
        }

        public void Load(int scene, bool setActive, UnityAction<SceneProcessState> action)
        {
            Load(new int[] { scene }, (setActive ? scene : -1), action);
        }

        public void Load(IEnumerable<int> scene, int activeScene, UnityAction<SceneProcessState> action)
        {
            var nState = new SceneProcessState()
            {
                unloadTargets = new List<int>(),
                loadTargets = new List<int>(scene),
                setActiveScene = activeScene,
            };

            StartCoroutine(ProcessState(nState, action));
        }

        public void Unload(int scene)
        {
            Unload(new int[] { scene }, null);
        }

        public void Unload(IEnumerable<int> scene)
        {
            Unload(scene, null);
        }

        public void Unload(int scene, UnityAction<SceneProcessState> action)
        {
            Unload(new int[] { scene }, action);
        }

        public void Unload(IEnumerable<int> scene, UnityAction<SceneProcessState> action)
        {
            var nState = new SceneProcessState()
            {
                unloadTargets = new List<int>(),
                loadTargets = new List<int>(scene),
                setActiveScene = -1,
            };

            StartCoroutine(ProcessState(nState, action));
        }

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
