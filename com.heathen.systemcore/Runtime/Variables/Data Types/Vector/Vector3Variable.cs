#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Values/Vector3")]
    public class Vector3Variable : DataVariable<float3>
    { }
}
#endif