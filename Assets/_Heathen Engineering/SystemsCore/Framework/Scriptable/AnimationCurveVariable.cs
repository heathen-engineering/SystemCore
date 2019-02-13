using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "Reference Variables/Animation Curve")]
    public class AnimationCurveVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public AnimationCurve curve;
    }
}
