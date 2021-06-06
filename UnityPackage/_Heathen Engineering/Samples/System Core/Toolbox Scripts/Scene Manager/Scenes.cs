using HeathenEngineering.Scriptable;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace HeathenEngineering.Tools
{
    /// <summary>
    /// Static access point to the active Scenes Manager and its related funcitonality
    /// </summary>
    public static class Scenes
    {
        /// <summary>
        /// A reference to the active scenes manager
        /// </summary>
        public static ScenesManager manager;

        /// <summary>
        /// Returns true when the bootstrap scene (build index 0) is loaded
        /// </summary>
        public static bool isBootstrapLoaded
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
        public static bool isEntryLoaded
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
        public static Scene Bootstrap
        {
            get
            {
                return SceneManager.GetSceneByBuildIndex(0);
            }
        }

        /// <summary>
        /// Scene reference for the entry scene (scene at build index 1)
        /// </summary>
        public static Scene Entry
        {
            get
            {
                return SceneManager.GetSceneByBuildIndex(1);
            }
        }

        /// <summary>
        /// Returns the number of scenes currently loaded
        /// </summary>
        public static int CountLoaded
        {
            get
            {
                return SceneManager.sceneCount;
            }
        }

        /// <summary>
        /// Returns the number of scenes defined in the build settings
        /// </summary>
        public static int CountAll
        {
            get
            {
                return SceneManager.sceneCountInBuildSettings;
            }
        }

        /// <summary>
        /// Creates a list reference of all the scenes that are currently loaded.
        /// </summary>
        public static List<Scene> Loaded
        {
            get
            {
                List<Scene> results = new List<Scene>();
                var count = SceneManager.sceneCount;
                for (int i = 0; i < count; i++)
                {
                    var scene = SceneManager.GetSceneAt(i);
                    if (scene.IsValid() && scene.isLoaded)
                        results.Add(scene);
                }

                return results;
            }
        }

        /// <summary>
        /// List the scenes available to be loaded
        /// </summary>
        public static List<Scene> Available
        {
            get
            {
                List<Scene> results = new List<Scene>();
                var count = SceneManager.sceneCountInBuildSettings;
                for (int i = 0; i < count; i++)
                {
                    results.Add(SceneManager.GetSceneByBuildIndex(i));
                }

                return results;
            }
        }

        /// <summary>
        /// Returns true if a scene with this name is loaded
        /// </summary>
        /// <param name="sceneName">The name of the scene to test</param>
        /// <returns></returns>
        public static bool IsSceneLoaded(string sceneName)
        {
            return SceneManager.GetSceneByName(sceneName).isLoaded;
        }

        /// <summary>
        /// Returns true if the scene at this build index is loaded
        /// </summary>
        /// <param name="buildIndex">The build index of the scene to test</param>
        /// <returns></returns>
        public static bool IsSceneLoaded(int buildIndex)
        {
            return SceneManager.GetSceneByBuildIndex(buildIndex).isLoaded;
        }

        /// <summary>
        /// Loads the entry scene (build index 1) if required and unloads all other scenes (except bootstrap [build index 0])
        /// </summary>
        public static void ReturnToEntry()
        {
            ReturnToEntry(null);
        }

        /// <summary>
        /// Loads the entry scene (build index 1) if required and unloads all other scenes (except bootstrap [build index 0])
        /// </summary>
        /// <param name="action">Called when the process is completed.</param>
        public static void ReturnToEntry(UnityAction<SceneProcessState> action)
        {
            if (manager == null)
                Debug.LogError("Attempted to return to menu but has not initalized a Scenes Manager.");

            manager.ReturnToEntry(action);
        }

        /// <summary>
        /// Loads one scene while unloading another raising started, updated and completed events as required. 
        /// </summary>
        /// <param name="from">The scene to transition from, this will be unloaded</param>
        /// <param name="to">The scene to transition to, this will be loaded</param>
        /// <param name="setToAsActive">If true the "to" scene will be set as the active scene</param>
        public static void Transition(string from, string to, bool setToAsActive)
        {
            Transition(new string[] { from }, new string[] { to }, setToAsActive ? to : "", null);
        }

        /// <summary>
        /// Loads one scene while unloading another raising started, updated and completed events as required. 
        /// </summary>
        /// <param name="from">The scene to transition from, this will be unloaded</param>
        /// <param name="to">The scene to transition to, this will be loaded</param>
        /// <param name="setToAsActive">If true the "to" scene will be set as the active scene</param>
        public static void Transition(int from, int to, bool setToAsActive)
        {
            Transition(new int[] { from }, new int[] { to }, setToAsActive ? to : -1, null);
        }

        /// <summary>
        /// Loads one scene while unloading another raising started, updated and completed events as required. 
        /// </summary>
        /// <param name="from">The scenes to transition from, this will be unloaded</param>
        /// <param name="to">The scenes to transition to, this will be loaded</param>
        ///<param name="activeScene">The scene to set as the active scene</param>
        public static void Transition(IEnumerable<string> from, IEnumerable<string> to, string activeScene)
        {
            Transition(from, to, activeScene, null);
        }

        /// <summary>
        /// Loads one scene while unloading another raising started, updated and completed events as required. 
        /// </summary>
        /// <param name="from">The scenes to transition from, this will be unloaded</param>
        /// <param name="to">The scenes to transition to, this will be loaded</param>
        ///<param name="activeScene">The scene to set as the active scene</param>
        public static void Transition(IEnumerable<int> from, IEnumerable<int> to, int activeScene)
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
        public static void Transition(string from, string to, bool setToAsActive, UnityAction<SceneProcessState> action)
        {
            Transition(new string[] { from }, new string[] { to }, setToAsActive ? to : string.Empty, action);
        }

        /// <summary>
        /// Loads one scene while unloading another raising started, updated and completed events as required. 
        /// </summary>
        /// <param name="from">The scene to transition from, this will be unloaded</param>
        /// <param name="to">The scene to transition to, this will be loaded</param>
        /// <param name="setToAsActive">If true the "to" scene will be set as the active scene</param>
        /// <param name="action">Called when the process completes</param>
        public static void Transition(int from, int to, bool setToAsActive, UnityAction<SceneProcessState> action)
        {
            Transition(new int[] { from }, new int[] { to }, setToAsActive ? to : -1, action);
        }

        /// <summary>
        /// Loads one scene while unloading another raising started, updated and completed events as required. 
        /// </summary>
        /// <param name="from">The scenes to transition from, this will be unloaded</param>
        /// <param name="to">The scenes to transition to, this will be loaded</param>
        /// <param name="action">Called when the process completes</param>
        public static void Transition(IEnumerable<string> from, IEnumerable<string> to, UnityAction<SceneProcessState> action)
        {
            Transition(from, to, string.Empty, action);
        }

        /// <summary>
        /// Loads one scene while unloading another raising started, updated and completed events as required. 
        /// </summary>
        /// <param name="from">The scenes to transition from, this will be unloaded</param>
        /// <param name="to">The scenes to transition to, this will be loaded</param>
        /// <param name="action">Called when the process completes</param>
        public static void Transition(IEnumerable<int> from, IEnumerable<int> to, UnityAction<SceneProcessState> action)
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
        public static void Transition(IEnumerable<string> from, IEnumerable<string> to, string activeScene, UnityAction<SceneProcessState> action)
        {
            if (manager == null)
                Debug.LogError("Attempted to transition scenes but has not initalized a Scenes Manager.");

            List<int> fromIndexs = new List<int>();
            List<int> toIndexes = new List<int>();
            int activeIndex = string.IsNullOrEmpty(activeScene) ? -1 : SceneManager.GetSceneByName(activeScene).buildIndex;

            foreach(var fromscene in from)
            {
                fromIndexs.Add(SceneManager.GetSceneByName(fromscene).buildIndex);
            }

            foreach (var toscene in to)
            {
                toIndexes.Add(SceneManager.GetSceneByName(toscene).buildIndex);
            }

            manager.Transition(fromIndexs, toIndexes, activeIndex, action);
        }

        /// <summary>
        /// Loads one scene while unloading another raising started, updated and completed events as required. 
        /// </summary>
        /// <param name="from">The scenes to transition from, this will be unloaded</param>
        /// <param name="to">The scenes to transition to, this will be loaded</param>
        ///<param name="activeScene">The scene to set as thee active scene</param>
        /// <param name="action">Called when the process completes</param>
        public static void Transition(IEnumerable<int> from, IEnumerable<int> to, int activeScene, UnityAction<SceneProcessState> action)
        {
            if (manager == null)
                Debug.LogError("Attempted to transition scenes but has not initalized a Scenes Manager.");

            manager.Transition(from, to, activeScene, action);
        }

        /// <summary>
        /// Loads a given scene optionally setting it as the active scene
        /// </summary>
        /// <param name="scene">The build index of the scene to load</param>
        /// <param name="setActive">Should this scene be set active when loaded</param>
        public static void Load(string scene, bool setActive)
        {
            Load(new string[] { scene }, (setActive ? scene : string.Empty), null);
        }

        /// <summary>
        /// Loads a given scene optionally setting it as the active scene
        /// </summary>
        /// <param name="scene">The build index of the scene to load</param>
        /// <param name="setActive">Should this scene be set active when loaded</param>
        public static void Load(int scene, bool setActive)
        {
            Load(new int[] { scene }, (setActive ? scene : -1), null);
        }

        /// <summary>
        /// Loads multiple scenes setting one as active when complete
        /// </summary>
        /// <param name="scenes">The scens to load</param>
        /// <param name="activeScene">The scene to set active, -1 indicates that no scene should be set active, this will leave active scene up to Unity</param>
        public static void Load(IEnumerable<string> scene, string activeScene)
        {
            Load(scene, activeScene, null);
        }

        /// <summary>
        /// Loads multiple scenes setting one as active when complete
        /// </summary>
        /// <param name="scenes">The scens to load</param>
        /// <param name="activeScene">The scene to set active, -1 indicates that no scene should be set active, this will leave active scene up to Unity</param>
        public static void Load(IEnumerable<int> scene, int activeScene)
        {
            Load(scene, activeScene, null);
        }

        /// <summary>
        /// Loads a scene and optioanlly sets it as active
        /// </summary>
        /// <param name="scene">The build index of the scene to load</param>
        /// <param name="setActive">Should the scene be set active when loaded</param>
        /// <param name="action">This is called when the process completes</param>
        public static void Load(string scene, bool setActive, UnityAction<SceneProcessState> action)
        {
            Load(new string[] { scene }, (setActive ? scene : string.Empty), action);
        }

        /// <summary>
        /// Loads a scene and optioanlly sets it as active
        /// </summary>
        /// <param name="scene">The build index of the scene to load</param>
        /// <param name="setActive">Should the scene be set active when loaded</param>
        /// <param name="action">This is called when the process completes</param>
        public static void Load(int scene, bool setActive, UnityAction<SceneProcessState> action)
        {
            Load(new int[] { scene }, (setActive ? scene : -1), action);
        }

        /// <summary>
        /// Loads multiple scenes optionally setting one as active and calling an action when complete
        /// </summary>
        /// <param name="scenes">The scenes to load</param>
        /// <param name="activeScene">The scene to set active ... if -1 no scene will be set active</param>
        /// <param name="action">The action to call when the process is complete</param>
        public static void Load(IEnumerable<string> scene, string activeScene, UnityAction<SceneProcessState> action)
        {
            if (manager == null)
                Debug.LogError("Attempted to load 1 or more scenes but has not initalized a Scenes Manager.");

            List<int> indexScenes = new List<int>();
            int activeSceneIndex = string.IsNullOrEmpty(activeScene) ? -1 : SceneManager.GetSceneByName(activeScene).buildIndex;

            foreach(var s in scene)
            {
                indexScenes.Add(SceneManager.GetSceneByName(s).buildIndex);
            }

            manager.Load(indexScenes, activeSceneIndex, action);
        }

        /// <summary>
        /// Loads multiple scenes optionally setting one as active and calling an action when complete
        /// </summary>
        /// <param name="scenes">The scenes to load</param>
        /// <param name="activeScene">The scene to set active ... if -1 no scene will be set active</param>
        /// <param name="action">The action to call when the process is complete</param>
        public static void Load(IEnumerable<int> scene, int activeScene, UnityAction<SceneProcessState> action)
        {
            if (manager == null)
                Debug.LogError("Attempted to load 1 or more scenes but has not initalized a Scenes Manager.");

            manager.Load(scene, activeScene, action);
        }

        /// <summary>
        /// Unload the indicated scene if its loaded
        /// </summary>
        /// <remarks>It is more efficent to use the build index variant of this method <see cref="Unload(int)"/></remarks>
        /// <param name="scene">The scene to unload</param>
        public static void Unload(string scene)
        {
            Unload(SceneManager.GetSceneByName(scene).buildIndex);
        }

        /// <summary>
        /// Unload the indicated scene if its loaded
        /// </summary>
        /// <param name="scene">The scene to unload</param>
        public static void Unload(int scene)
        {
            Unload(new int[] { scene }, null);
        }

        /// <summary>
        /// Unload the indicated scenes if they are loaded.
        /// </summary>
        /// <remarks>
        /// It is more efficent to use the build index variant of this method <see cref="Unload(IEnumerable{int})"/>
        /// </remarks>
        /// <param name="scenes">The scenes to unload</param>
        public static void Unload(IEnumerable<string> scenes)
        {
            List<int> targetScenes = new List<int>();

            foreach(var scene in scenes)
            {
                targetScenes.Add(SceneManager.GetSceneByName(scene).buildIndex);
            }

            Unload(targetScenes, null);
        }

        /// <summary>
        /// Unload the indicated scenes if they are loaded.
        /// </summary>
        /// <param name="scenes">The scenes to unload</param>
        public static void Unload(IEnumerable<int> scene)
        {
            Unload(scene, null);
        }

        /// <summary>
        /// Unloads the indicated scene and calls the indicated action when complete
        /// </summary>
        /// <param name="scene">The scene to unload</param>
        /// <param name="action">This is called when the process is complete</param>
        public static void Unload(int scene, UnityAction<SceneProcessState> action)
        {
            Unload(new int[] { scene }, action);
        }

        /// <summary>
        /// Unloads multiple scenes if they are loaded and calls the indicated action when the process is complete
        /// </summary>
        /// <remarks>it is more efficent to use the build index version of this method <see cref="Unload(IEnumerable{int}, UnityAction{SceneProcessState})"/></remarks>
        /// <param name="scenes">The scenes to be unloaded</param>
        /// <param name="action">The action to call when complete</param>
        public static void Unload(IEnumerable<string> scenes, UnityAction<SceneProcessState> action)
        {
            List<int> targetScenes = new List<int>();

            foreach (var scene in scenes)
            {
                targetScenes.Add(SceneManager.GetSceneByName(scene).buildIndex);
            }

            Unload(targetScenes, action);
        }

        /// <summary>
        /// Unloads multiple scenes if they are loaded and calls the indicated action when the process is complete
        /// </summary>
        /// <param name="scenes">The scenes to be unloaded</param>
        /// <param name="action">The action to call when complete</param>
        public static void Unload(IEnumerable<int> scene, UnityAction<SceneProcessState> action)
        {
            if (manager == null)
                Debug.LogError("Attempted to unload 1 or more scenes but has not initalized a Scenes Manager.");

            manager.Unload(scene, action);
        }

        /// <summary>
        /// Sets the indicated scene as active if its loaded.
        /// </summary>
        /// <param name="buildIndex">The build index of the scene to set active</param>
        public static void SetSceneActive(int buildIndex)
        {
            if (buildIndex < 0)
                return;

            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(buildIndex));
        }
    }
}
