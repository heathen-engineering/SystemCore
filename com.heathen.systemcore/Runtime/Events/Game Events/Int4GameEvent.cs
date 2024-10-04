#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Simple Events/Int 4")]
    public class Int4GameEvent : GameEvent<int4>
    { }
}
#endif
