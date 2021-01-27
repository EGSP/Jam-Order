namespace Game.GameEvents
{
    public abstract class Effect
    {
        public abstract string Id { get; }
        public EffectType Type { get; protected set; }

        protected Effect(EffectType type)
        {
            Type = type;
        }
    }
    
    public abstract class Effect<TEffect>: Effect where TEffect : Effect<TEffect>
    {
        public override string Id => typeof(TEffect).Name.ToLower();

        protected Effect(EffectType type) : base(type)
        {
        }
    }
}