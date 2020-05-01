using HeathenEngineering.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.Tools.Demo
{
    /// <summary>
    /// A quick slopy example of handling damage from system that reports via the DamageHandler tool
    /// </summary>
    public class HitIndicator : MonoBehaviour, IDamageHandler<DamageHandler.Report>
    {
        public Color normalColor;
        public Color hitColor;
        public float flashTime = 0.5f;
        public Rigidbody selfBody;
        public MeshRenderer selfRenderer;

        public void Update()
        {
            selfRenderer.material.color = Color.Lerp(selfRenderer.material.color, normalColor, Time.deltaTime * flashTime);
        }

        public void ApplyDamage(DamageHandler.Report data)
        {
            selfRenderer.material.color = hitColor;
            selfBody.AddForceAtPosition(data.damageValue * data.direction, data.worldPosition, ForceMode.Impulse);
        }
    }
}
