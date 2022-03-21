#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering.Events
{
    [CreateAssetMenu(menuName = "System Core/Events/Change Events/Unsigned Long")]
    public class UnsignedLongChangeEvent : ChangeEvent<ulong>
    { }
}
#endif