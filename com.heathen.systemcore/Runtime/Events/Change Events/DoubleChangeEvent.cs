#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Change Events/Double")]
    public class DoubleChangeEvent : ChangeEvent<double>
    { }
}
#endif