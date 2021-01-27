using Egsp.Core.Ui;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Visuals.GameEvents
{
    public class EffectVisual : Visual
    {
        [SerializeField] private Image image;

        public Sprite Sprite
        {
            set => image.sprite = value;
        }
    }
}