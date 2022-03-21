#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Simple Events/String")]
    public class StringGameEvent : GameEvent<string>
    { } 
}
#endif