#if HE_SYSCORE
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Lists/String")]
    public class StringListVariable : CollectionDataVariable<string>
    { }
}
#endif