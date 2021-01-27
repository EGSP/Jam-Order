using System;
using System.Collections.Generic;
using Egsp.Core;
using Game.GameEvents;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Visuals.GameEvents
{
    public class GameEventActionsController : ContextMonoBehaviour
    {
        [SerializeField] private TransformContainer actionsContainer;
        [SerializeField] private GameEventActionVisual actionVisualPrefab;
        
        public void Accept([NotNull] List<IGameEventAction> actions)
        {
            actionsContainer.Clear();
            foreach (var eventAction in actions)
            {
                var inst = actionsContainer.PutPrefab(actionVisualPrefab);
                
                inst.Accept(eventAction);
            }
        }
    }
}