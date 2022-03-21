#if HE_SYSCORE
using HeathenEngineering.Events;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Values/Unsigned Int")]
    public class UnsignedIntVariable : DataVariable<uint>
    { }
}
#endif