#if HE_SYSCORE
using HeathenEngineering.Events;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Values/Unsigned Long")]
    public class UnsignedLongVariable : DataVariable<ulong>
    { }
}
#endif