#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Pointers/Values/Animation Curve")]
    public class AnimationCurveVariable : DataVariable<AnimationCurve>
    { }
}
#endif