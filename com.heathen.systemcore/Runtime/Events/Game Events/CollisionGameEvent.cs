#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Simple Events/Collision")]
    public class CollisionGameEvent : GameEvent<Collision>
    { }
}
#endif