#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Pointers/Values/Transform")]
    public class TransformPointerVariable : DataVariable<Transform>
    { }
}
#endif