using System.Collections.Generic;

namespace Game.GameEvents
{
    public class AbandonedMonasteryEvent : GameEvent<AbandonedMonasteryEvent>
    {
        public override string Name => "Заброшенный монастырь.";
        public override string Description => "Вы нашли заброшенный монастырь посреди равнины..";

        public override List<IGameEventAction> GetActions(Order order)
        {
            var list = new List<IGameEventAction>();
            list.Add(new GameEventAction("Обустроить.",
                new MemberEffect(EffectType.Positive)));
            
            list.Add(new GameEventAction("Сравнять с землей!",
                new DeterrenceEffect(EffectType.Positive)));
            
            list.Add(new GameEventAction("Пройти мимо.."));

            return list;
        }
    }
}