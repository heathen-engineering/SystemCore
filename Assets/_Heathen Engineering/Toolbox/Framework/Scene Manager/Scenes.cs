using HeathenEngineering.Scriptable;
using System;
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
        public static ScenesManager manager;

        public static bool isMainLoaded
        {
            get
            {
                var scene = SceneManager.GetSceneByBuildIndex(0);
                return scene.IsValid() && scene.isLoaded;
            }
        }

        public static bool isMenuLoaded
        {
            get
            {
                var scene = SceneManager.GetSceneByBuildIndex(1);
                return scene.IsValid() && scene.isLoaded;
            }
        }

        public static Scene Main
        {
            get
            {
                return SceneManager.GetSceneByBuildIndex(0);
            }
        }

        public static Scene Menu
        {
            get
            {
                return SceneManager.GetSceneByBuildIndex(1);
            }
        }

        public static int CountLoaded
        {
            get
            {
                return SceneManager.sceneCount;
            }
        }

        public static int CountAll
        {
            get
            {
                return SceneManager.sceneCountInBuildSettings;
            }
        }

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

        public static bool IsSceneLoaded(string sceneName)
        {
            return SceneManager.GetSceneByName(sceneName).isLoaded;
        }

        public static bool IsSceneLoaded(int buildIndex)
        {
            return SceneManager.GetSceneByBuildIndex(buildIndex).isLoaded;
        }

        public static void ReturnToMenu()
        {
            ReturnToMenu(null);
        }

        public static void ReturnToMenu(UnityAction<SceneProcessState> action)
        {
            if (manager == null)
                Debug.LogError("Attempted to return to menu but has not initalized a Scenes Manager.");

            manager.ReturnToMenu(action);
        }

        public static void Transition(int from, int to, bool setToAsActive)
        {
            Transition(new int[] { from }, new int[] { to }, setToAsActive ? to : -1, null);
        }

        public static void Transition(IEnumerable<int> from, IEnumerable<int> to, int activeScene)
        {
            Transition(from, to, activeScene, null);
        }

        public static void Transition(int from, int to, bool setToAsActive, UnityAction<SceneProcessState> action)
        {
            Transition(new int[] { from }, new int[] { to }, setToAsActive ? to : -1, action);
        }

        public static void Transition(IEnumerable<int> from, IEnumerable<int> to, UnityAction<SceneProcessState> action)
        {
            Transition(from, to, -1, action);
        }

        public static void Transition(IEnumerable<int> from, IEnumerable<int> to, int activeScene, UnityAction<SceneProcessState> action)
        {
            if (manager == null)
                Debug.LogError("Attempted to transition scenes but has not initalized a Scenes Manager.");

            manager.Transition(from, to, activeScene, action);
        }

        public static void Load(int scene, bool setActive)
        {
            Load(new int[] { scene }, (setActive ? scene : -1), null);
        }

        public static void Load(IEnumerable<int> scene, int activeScene)
        {
            Load(scene, activeScene, null);
        }

        public static void Load(int scene, bool setActive, UnityAction<SceneProcessState> action)
        {
            Load(new int[] { scene }, (setActive ? scene : -1), action);
        }

        public static void Load(IEnumerable<int> scene, int activeScene, UnityAction<SceneProcessState> action)
        {
            if (manager == null)
                Debug.LogError("Attempted to load 1 or more scenes but has not initalized a Scenes Manager.");

            manager.Load(scene, activeScene, action);
        }

        public static void Unload(int scene)
        {
            Unload(new int[] { scene }, null);
        }

        public static void Unload(IEnumerable<int> scene)
        {
            Unload(scene, null);
        }

        public static void Unload(int scene, UnityAction<SceneProcessState> action)
        {
            Unload(new int[] { scene }, action);
        }

        public static void Unload(IEnumerable<int> scene, UnityAction<SceneProcessState> action)
        {
            if (manager == null)
                Debug.LogError("Attempted to unload 1 or more scenes but has not initalized a Scenes Manager.");

            manager.Unload(scene, action);
        }

        public static void SetSceneActive(int buildIndex)
        {
            if (buildIndex < 0)
                return;

            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(buildIndex));
        }
    }
}
