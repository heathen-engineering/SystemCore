using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Lists/Quaternion")]
    public class QuaternionListVariable : CollectionDataVariable<SerializableQuaternion>
    { }
}
