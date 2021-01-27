using Egsp.Core;
using Egsp.Core.Ui;
using Game.GameEvents;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Visuals.GameEvents
{
    public class GameEventActionVisual : ContextVisual
    {
        [SerializeField] private TransformContainer effectsContainer;
        [SerializeField] private TMP_Text descriptionText;

        [SerializeField] private EffectVisual effectVisualPrefab;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
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

            _button.onClick.AddListener(() =>
            {
                Debug.Log("clicked");
                Bus?.Raise<IGameEventActionListener>(
                    x => x.OnEventAction(eventAction));
            });
        }
    }
}