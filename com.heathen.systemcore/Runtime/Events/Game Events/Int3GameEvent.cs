#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Simple Events/Int 3")]
    public class Int3GameEvent : GameEvent<int3>
    { }
}
#endif
