#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Simple Events/Float 3")]
    public class Float3GameEvent : GameEvent<float3>
    { }
}
#endif