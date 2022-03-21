#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Simple Events/Double")]
    public class DoubleGameEvent : GameEvent<double>
    { }
}
#endif