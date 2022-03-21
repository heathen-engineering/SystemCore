#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Pointers/Lists/Transform")]
    public class TransformPointerListVariable : CollectionDataVariable<Transform>
    { }
}
#endif