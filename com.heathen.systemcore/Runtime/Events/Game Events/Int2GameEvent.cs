#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Simple Events/Int 2")]
    public class Int2GameEvent : GameEvent<int2>
    { }
}
#endif
