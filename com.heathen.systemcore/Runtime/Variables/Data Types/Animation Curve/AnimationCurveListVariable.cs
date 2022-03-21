#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Pointers/Lists/Animation Curve")]
    public class AnimationCurveListVariable : CollectionDataVariable<AnimationCurve>
    { }
}
#endif