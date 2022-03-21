#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering.Events
{

    [CreateAssetMenu(menuName = "System Core/Events/Change Events/Float")]
    public class FloatChangeEvent : ChangeEvent<float>
    { }
}
#endif