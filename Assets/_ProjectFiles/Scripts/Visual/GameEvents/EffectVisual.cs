using Egsp.Core.Ui;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Visual.GameEvents
{
    public class EffectVisual : Visual<EffectVisual>
    {
        [SerializeField] private Image image;

        public Sprite Sprite
        {
            set => image.sprite = value;
        }
    }
}