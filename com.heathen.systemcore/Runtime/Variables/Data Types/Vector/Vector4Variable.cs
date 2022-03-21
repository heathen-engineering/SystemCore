#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Values/Vector4")]
    public class Vector4Variable : DataVariable<float4>
    {}
}
#endif