#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Lists/Vector3")]
    public class Vector3ListVariable : CollectionDataVariable<float3>
    { }
}
#endif