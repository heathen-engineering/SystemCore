#if HE_SYSCORE
using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering
{
    [CreateAssetMenu(menuName = "System Core/Variables/Serializable/Values/RectTransform")]
    public class RectTransformVariable : DataVariable<SerializableRectTransform>
    { }
}
#endif