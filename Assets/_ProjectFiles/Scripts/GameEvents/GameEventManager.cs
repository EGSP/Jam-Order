using System;
using System.Collections.Generic;
using Egsp.Extensions.Linq;
using Game.Visuals.GameEvents;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Game.GameEvents
{
    public class GameEventManager : SerializedMonoBehaviour, IGameEventActionListener
    {
        [SerializeField] private GameEventVisual gameEventVisual;
        [SerializeField] private GameEventActionsController gameEventActionsController;

        [OdinSerialize] public List<IGameEvent> GameEvents;
        
        [OdinSerialize] public Order Order { get; set; }

        public event Action<IGameEventAction> OnGameEventAction = delegate(IGameEventAction action) {  };

        private void Start()
        {
            gameEventActionsController.Bus?
                .Subscribe<IGameEventActionListener>(this);
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

        [Button]
        public void CloseGameEvent()
        {
            gameEventVisual.gameObject.SetActive(false);
            gameEventActionsController.gameObject.SetActive(false);
        }

        public void OnEventAction(IGameEventAction eventAction)
        {
            Debug.Log(eventAction.Description);
            OnGameEventAction(eventAction);
        }
    }
}