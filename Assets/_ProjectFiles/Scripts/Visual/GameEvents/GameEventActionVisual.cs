using System;
using Egsp.Core;
using Egsp.Core.Ui;
using Game.GameEvents;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Visual.GameEvents
{
    public class GameEventActionVisual : Visual<GameEventActionVisual>
    {
        [SerializeField] private TransformContainer effectsContainer;
        [SerializeField] private TMP_Text descriptionText;

        [SerializeField] private EffectVisual effectVisualPrefab;

        private Button button;

        public event Action<IGameEventAction> OnClick = delegate(IGameEventAction action) {  };

        private void Awake()
        {
            button = GetComponent<Button>();
        }


        public void Accept(IGameEventAction eventAction)
        {
            effectsContainer.Clear();
            descriptionText.text = eventAction.Description;

            var effects = eventAction.GetActionEffects();

            if (effects == null)
                return;

            foreach (var effect in effects)
            {
                var inst = effectsContainer.PutPrefab(effectVisualPrefab);
                inst.Sprite = AssetStorage.Instance.GetSpriteById(effect.Id);
            }

            button.onClick.AddListener(() => OnClick(eventAction));
        }
    }
}