using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "Reference Variables/Game Object")]
    public class GameObjectVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public GameObject gameObject;
    }
}
