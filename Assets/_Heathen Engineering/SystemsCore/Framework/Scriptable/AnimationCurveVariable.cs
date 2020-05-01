using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    /// <summary>
    /// <para>A data variable such as this represents this data type in your project folder as a scriptable object. The core benifit to doing this is that you can then reference this field on any script in any scene as a shared point of data without the need of singletons or other dependency breaking paradigms.</para>
    /// <para>In addition to the ease of reference even across scenes, scriptable object like these aka Scriptable Variables can be organized into data libraries and serialized as save files easily loaded at run time and always available with no initalization testing required.</para>
    /// <para>You can create custom 'Scriptable Variables' by creating a ScriptableObject that has a value of the data type you wish to define.</para>
    /// </summary>
    [CreateAssetMenu(menuName = "Reference Variables/Animation Curve")]
    public class AnimationCurveVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public AnimationCurve curve = AnimationCurve.Linear(0, 1, 1, 1);
    }
}
