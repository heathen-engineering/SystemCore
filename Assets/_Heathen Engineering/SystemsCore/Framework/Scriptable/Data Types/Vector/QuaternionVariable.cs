using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering.Scriptable
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Values/Quaternion")]
    public class QuaternionVariable : DataVariable<SerializableQuaternion>
    { }
}
