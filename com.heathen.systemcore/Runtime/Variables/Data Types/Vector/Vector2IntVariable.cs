#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Values/Vector2Int")]
    public class Vector2IntVariable : DataVariable<int2>
    { }
}
#endif