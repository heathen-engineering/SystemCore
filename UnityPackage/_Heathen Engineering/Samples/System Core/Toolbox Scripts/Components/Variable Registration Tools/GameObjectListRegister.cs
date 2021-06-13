using HeathenEngineering.Scriptable;
using System;
using UnityEngine;

namespace HeathenEngineering.Tools
{
    [AddComponentMenu("System Core/Tools/Game Object List Register")]
    public class GameObjectListRegister : MonoBehaviour
    {
        public GameObjectPointerListVariable TargetList;

        private void OnEnable()
        {
            if (TargetList != null)
                TargetList.Add(gameObject);
        }

        private void OnDisable()
        {
            if (TargetList != null)
                TargetList.Remove(gameObject);
        }
    }
}
