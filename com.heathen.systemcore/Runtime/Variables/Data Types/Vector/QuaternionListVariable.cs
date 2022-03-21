#if HE_SYSCORE
using Unity.Mathematics;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Lists/Quaternion")]
    public class QuaternionListVariable : CollectionDataVariable<quaternion>
    { }
}
#endif