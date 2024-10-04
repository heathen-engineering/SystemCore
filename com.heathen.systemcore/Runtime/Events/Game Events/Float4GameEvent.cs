#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Simple Events/Float 4")]
    public class Float4GameEvent : GameEvent<float4>
    { }
}
#endif