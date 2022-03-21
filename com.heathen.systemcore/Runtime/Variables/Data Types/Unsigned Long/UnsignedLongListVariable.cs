#if HE_SYSCORE
using HeathenEngineering.Events;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Lists/Unsigned Long")]
    public class UnsignedLongListVariable : DataVariable<List<ulong>>
    { }
}
#endif