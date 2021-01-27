using Egsp.Core.Ui;
using Game.GameEvents;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Visual.GameEvents
{
    public class GameEventVisual : Visual<GameEventVisual>
    {
        [SerializeField] private Image image;
        [SerializeField] private TMP_Text description;

        public void Accept(IGameEvent gameEvent)
        {
            var id = gameEvent.Id;
            description.text = gameEvent.Description;

            var sprite = AssetStorage.Instance.GetSpriteById(id);
            image.sprite = sprite;
        }
    }
}