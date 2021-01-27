namespace Game.GameEvents
{
    public class MemberEffect : Effect<MemberEffect>
    {
        public MemberEffect(EffectType type) : base(type)
        {
        }
    }
    
    public class HolinessEffect : Effect<HolinessEffect>
    {
        public HolinessEffect(EffectType type) : base(type)
        {
        }
    }
    
    public class DeterrenceEffect : Effect<HolinessEffect>
    {
        public DeterrenceEffect(EffectType type) : base(type)
        {
        }
    }
    
    public class AdoptionEffect : Effect<AdoptionEffect>
    {
        public AdoptionEffect(EffectType type) : base(type)
        {
        }
    }
    
    public class TerrorEffect : Effect<TerrorEffect>
    {
        public TerrorEffect(EffectType type) : base(type)
        {
        }
    }
}