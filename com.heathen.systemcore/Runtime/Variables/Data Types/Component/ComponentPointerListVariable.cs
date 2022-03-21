#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Pointers/Lists/Component")]
    public class ComponentPointerListVariable : CollectionDataVariable<Component>
    { }
}
#endif