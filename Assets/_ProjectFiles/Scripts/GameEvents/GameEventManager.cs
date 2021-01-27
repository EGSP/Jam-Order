using System;
using System.Collections.Generic;
using Egsp.Extensions.Linq;
using Game.Visual.GameEvents;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Game.GameEvents
{
    public class GameEventManager : SerializedMonoBehaviour
    {
        [SerializeField] private GameEventVisual gameEventVisual;
        [SerializeField] private GameEventActionsController gameEventActionsController;

        [OdinSerialize] public List<IGameEvent> GameEvents;
        
        [OdinSerialize] public Order Order { get; set; }

        public event Action<IGameEventAction> OnEventAction = delegate(IGameEventAction action) {  };

        private void Awake()
        {
            gameEventActionsController.OnEventAction += OnGameEventAction;
        }

        public IGameEvent GetRandomEvent()
        {
            if (GameEvents == null || GameEvents.Count == 0)
                return new NothingGameEvent();

            return GameEvents.RandomBySeed();
        }

        [Button]
        public void ShowGameEvent(IGameEvent gameEvent)
        {
            gameEventVisual.gameObject.SetActive(true);
            gameEventVisual.Accept(gameEvent);
            
            gameEventActionsController.gameObject.SetActive(true);

            var effects = gameEvent.GetActions(Order);
            gameEventActionsController.Accept(effects??new List<IGameEventAction>());
        }

        public void ShowRandomEvent()
        {
            ShowGameEvent(GetRandomEvent());
        }

        private void OnGameEventAction(IGameEventAction gea)
        {
            Debug.Log(gea.Description);
            OnEventAction(gea);
        }

        [Button]
        public void CloseGameEvent()
        {
            gameEventVisual.gameObject.SetActive(false);
            gameEventActionsController.gameObject.SetActive(false);
        }
    }
}