using Egsp.Core.Ui;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Visual
{
    public class OrderReputationVisual : Visual<OrderReputationVisual>
    {
        [SerializeField] private Slider slider;

        public int MaxValue { get; set; } = 100;
        
        public void SetReputation(int value)
        {
            slider.value = (float)value/(float)MaxValue;
        }
    }
}