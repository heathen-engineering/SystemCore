using HeathenEngineering.Events;
using HeathenEngineering.Scriptable;
using HeathenEngineering.Serializable;
using UnityEngine;

namespace HeathenEngineering.UIX
{

    [RequireComponent(typeof(UnityEngine.UI.Image))]
    [AddComponentMenu("System Core/Tools/Image Sync")]
    public class ImageSync : MonoBehaviour
    {
        public SpritePointerVariable sprite;
        public ColorVariable color;
        public FloatVariable fillAmount;

        private UnityEngine.UI.Image targetImage;

        private void Start()
        {
            Refresh();
        }

        private void OnEnable()
        {
            targetImage = GetComponent<UnityEngine.UI.Image>();

            if (fillAmount != null)
                fillAmount.AddListener(HandleFillAmountChange);

            if (color != null)
                color.AddListener(HandleColorChange);

            if (sprite != null)
                sprite.AddListener(HandleSpriteChange);

            Refresh();
        }

        private void OnDisable()
        {
            if (fillAmount != null)
                fillAmount.RemoveListener(HandleFillAmountChange);

            if (color != null)
                color.RemoveListener(HandleColorChange);

            if (sprite != null)
                sprite.RemoveListener(HandleSpriteChange);
        }

        private void HandleSpriteChange(ChangeEventData<Sprite> data)
        {
            targetImage.sprite = data.newValue;
        }

        private void HandleColorChange(ChangeEventData<SerializableColor> data)
        {
            targetImage.color = data.newValue;
        }

        private void HandleFillAmountChange(ChangeEventData<float> data)
        {
            targetImage.fillAmount = data.newValue;
        }

        public void Refresh()
        {
            if (fillAmount != null)
                targetImage.fillAmount = fillAmount.Value;

            if (color != null)
                targetImage.color = color.Value;

            if (sprite != null)
                targetImage.sprite = sprite.Value;
        }
    }
}
