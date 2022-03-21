#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Values/Vector2")]
    public class Vector2Variable : DataVariable<float2>
    { }
}
#endif