using HeathenEngineering.Events;
using HeathenEngineering.Scriptable;
using UnityEngine;

namespace HeathenEngineering.Tools.Demo
{
    public class TestProcessStateGameEvents : MonoBehaviour
    {
        public SceneProcessStateGameEvent started;
        public SceneProcessStateGameEvent updated;
        public SceneProcessStateGameEvent completed;

        // Start is called before the first frame update
        void Start()
        {
            started.AddListener(HandleStarted);
            updated.AddListener(HandleUpdated);
            completed.AddListener(HandleCompleted);
        }

        private void HandleCompleted(EventData<SceneProcessState> data)
        {
            Debug.Log("Completed!\n" + data.value.ToString());
        }

        private void HandleUpdated(EventData<SceneProcessState> data)
        {
            Debug.Log("Updated!\n" + data.value.ToString());
        }

        private void HandleStarted(EventData<SceneProcessState> data)
        {
            Debug.Log("Started!\n" + data.value.ToString());
        }
    }
}
