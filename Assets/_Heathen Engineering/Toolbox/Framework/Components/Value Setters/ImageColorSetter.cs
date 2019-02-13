using HeathenEngineering.Scriptable;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.UIX
{
    [ExecuteInEditMode]
    [AddComponentMenu("Heathen/Varaibles/Image Color Setter")]
    public class ImageColorSetter : MonoBehaviour
    {
        public ColorReference Value = new ColorReference(Color.white);
        public List<UnityEngine.UI.Image> Images = new List<UnityEngine.UI.Image>();
        public bool alwaysApply = false;

        private void OnEnable()
        {
            Refresh();
        }

        private void Update()
        {
            if (alwaysApply || !Application.isPlaying)
            {
                Refresh();
            }
        }

        [ContextMenu("Refresh")]
        public void Refresh()
        {
            if (Images == null)
                return;

            foreach (var Image in Images)
            {
                if (Image != null)
                {
                    Image.color = Value;
                }
            }
        }
    }
}
