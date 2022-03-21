#if HE_SYSCORE
using UnityEngine;

namespace HeathenEngineering.Events
{
    //SceneProcessState
    [CreateAssetMenu(menuName = "System Core/Events/Simple Events/Scene Process State")]
    public class SceneProcessStateGameEvent : GameEvent<SceneProcessState>
    { }
}
#endif