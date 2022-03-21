#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Lists/Vector4")]
    public class Vector4ListVariable : CollectionDataVariable<float4>
    { }
}
#endif