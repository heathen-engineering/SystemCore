#if HE_SYSCORE
using HeathenEngineering.Events;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Lists/Long")]
    public class LongListVariable : DataVariable<List<long>>
    { }
}
#endif