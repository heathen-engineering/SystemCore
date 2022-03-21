#if HE_SYSCORE
using HeathenEngineering.Events;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Lists/Unsigned Int")]
    public class UnsignedIntListVariable : DataVariable<List<uint>>
    { }
}
#endif