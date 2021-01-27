﻿using System;
using System.Collections.Generic;
using Game.GameEvents;
using Game.Ui;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Visual.GameEvents
{
    public class GameEventActionsController : MonoBehaviour
    {
        [SerializeField] private TransformContainer actionsContainer;
        [SerializeField] private GameEventActionVisual actionVisualPrefab;
        
        public event Action<IGameEventAction> OnEventAction = delegate(IGameEventAction action) {  }; 
        
        public void Accept([NotNull] List<IGameEventAction> actions)
        {
            actionsContainer.Clear();
            foreach (var eventAction in actions)
            {
                var inst = actionsContainer.Put(actionVisualPrefab);
                
                inst.Accept(eventAction);
                ListenAction(inst);
            }
        }

        public void ListenAction(GameEventActionVisual eventActionVisual)
        {
            eventActionVisual.OnClick += InvokeEvent;
        }

        private void InvokeEvent(IGameEventAction eventAction)
        {
            OnEventAction(eventAction);
        }
    }
}