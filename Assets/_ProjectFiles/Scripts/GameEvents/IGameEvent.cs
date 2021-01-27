using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Game.GameEvents
{
    public interface IGameEvent
    {
        string Id { get; }
        string Name { get; }
        string Description { get; }

        [CanBeNull]
        List<IGameEventAction> GetActions([NotNull] Order order);
    }
    
    [Serializable]
    public abstract class GameEvent<TGameEvent> : IGameEvent where TGameEvent: IGameEvent
    {
        /// <summary>
        /// Создается по типу.
        /// </summary>
        public string Id => typeof(TGameEvent).Name.ToLower();

        public abstract string Name { get; }
        public abstract string Description { get; }

        
        public abstract List<IGameEventAction> GetActions(Order order);
    }

    public class NothingGameEvent : GameEvent<NothingGameEvent>
    {
        public override string Name => "Nothing";
        public override string Description => "Nothing will happen...";

        public override List<IGameEventAction> GetActions(Order order)
        {
            return null;
        }
    }

    public interface IGameEventAction
    {
        /// <summary>
        /// Описание действия.
        /// </summary>
        string Description { get; }
        
        [CanBeNull]
        IGameEvent NextStage { get; }

        [CanBeNull]
        List<Effect> GetActionEffects();
    }

    public class GameEventAction: IGameEventAction
    {
        private readonly Func<IGameEvent> nextStageFunc;
        private readonly Effect[] actionEffects;
        
        public string Description { get; }

        public IGameEvent NextStage
        {
            get
            {
                if (nextStageFunc == null)
                    return null;

                return nextStageFunc();
            }
        }

        
        /// <param name="description">Описание действия.</param>
        /// <param name="actionEffects">Эффекты действия.</param>
        public GameEventAction(string description, params Effect[] actionEffects)
        {
            this.actionEffects = actionEffects;
            Description = description;
        }

        
        /// <param name="nextStageFunc">Функция возвращающая следующий GameEvent.</param>
        public GameEventAction(string description, Func<IGameEvent> nextStageFunc, params Effect[] actionEffects)
            : this(description, actionEffects)
        {
            this.nextStageFunc = nextStageFunc;
        }
        
        public List<Effect> GetActionEffects()
        {
            return actionEffects?.ToList();
        }
    }

    public enum EffectType
    {
        Positive,
        Negative
    }
}