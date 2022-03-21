#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Lists/Vector2Int")]
    public class Vector2IntListVariable : CollectionDataVariable<int2>
    { }
}
#endif