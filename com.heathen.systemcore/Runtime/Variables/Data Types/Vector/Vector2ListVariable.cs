#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Lists/Vector2")]
    public class Vector2ListVariable : CollectionDataVariable<float2>
    { }
}
#endif