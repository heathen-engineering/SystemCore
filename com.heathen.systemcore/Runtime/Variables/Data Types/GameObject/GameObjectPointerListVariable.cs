#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Pointers/Lists/Game Object")]
    public class GameObjectPointerListVariable : CollectionDataVariable<GameObject>
    { }
}
#endif