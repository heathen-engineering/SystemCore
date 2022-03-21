#if HE_SYSCORE
using HeathenEngineering.Serializable;
using Unity.Mathematics;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Lists/Color")]
    public class ColorListVariable : CollectionDataVariable<float4>
    { }
}
#endif