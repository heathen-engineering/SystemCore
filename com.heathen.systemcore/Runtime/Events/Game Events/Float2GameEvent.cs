#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Simple Events/Float 2")]
    public class Float2GameEvent : GameEvent<float2>
    { }
}
#endif