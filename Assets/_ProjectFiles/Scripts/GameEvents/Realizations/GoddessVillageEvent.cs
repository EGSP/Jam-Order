using System.Collections.Generic;

namespace Game.GameEvents
{
    public class GoddessVillageEvent : GameEvent<GoddessVillageEvent>
    {
        public override string Name => "Интересные слухи";
        public override string Description => "Проходя через очередную деревню вы узнаете " +
                                              "о возможном существовании местой богини" +
                                              " и ее примерное местоположение.";

        public override List<IGameEventAction> GetActions(Order order)
        {
            return new List<IGameEventAction>()
            {
                new GameEventAction("Найти лже-Богиню", ()=> new GoddessFindEvent(),
                    new MemberEffect(EffectType.Positive), new TerrorEffect(EffectType.Positive)),
                new GameEventAction("Узнать больше", ()=>new GoddessResearchEvent()),
                new GameEventAction("Продолжить поход")
            };
        }
    }

    public class GoddessFindEvent : GameEvent<GoddessFindEvent>
    {
        public override string Name => "Лже-Богиня";
        public override string Description =>"Выйдя на октрытую местность за деревней, " +
                                             "вы обнаруживаете на небольшой поляне алтарь лже-Богини. " +
                                             "Также рядом стоят небольшие домики, судя по всему, еретиков.";

        public override List<IGameEventAction> GetActions(Order order)
        {
            return new List<IGameEventAction>()
            {
                new GameEventAction("Пресечь существование культа!", 
                    new MemberEffect(EffectType.Negative), new TerrorEffect(EffectType.Positive)),
                new GameEventAction("Оставить в покое еретиков.",
                    new HolinessEffect(EffectType.Positive), new DeterrenceEffect(EffectType.Negative))
            };
        }
    }
    
    public class GoddessResearchEvent : GameEvent<GoddessResearchEvent>
    {
        public override string Name =>"Слияние с толпой";
        public override string Description =>"Оставаясь в деревне," +
                                             " вы вслушиваетесь в разговоры местных жителей и собираете информацию" +
                                             "о культе лже-Богини." +
                                             " Как оказывается, уже много людей не придерживаются веры в Аота!";

        public override List<IGameEventAction> GetActions(Order order)
        {
            return new List<IGameEventAction>()
            {
                new GameEventAction("Сжечь деревню дотла!", ()=>new GoddessFindEvent(),
                    new TerrorEffect(EffectType.Positive), new HolinessEffect(EffectType.Negative)),
                new GameEventAction("Отправиться за лже-Богиней", ()=>new GoddessFindEvent()),
                new GameEventAction("Уйти с миром", new HolinessEffect(EffectType.Positive))
            };
        }
    }
}