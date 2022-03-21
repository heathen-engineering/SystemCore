#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Pointers/Values/Game Object")]
    public class GameObjectPointerVariable : DataVariable<GameObject>
    { }
}
#endif