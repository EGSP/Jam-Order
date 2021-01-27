using System;

namespace Game
{
    [Serializable]
    public class Order
    {
        public const int MaxReputationConst = 1000;
        public const int MinReputationConst = 0;

        public const int MaxPowerConst = 100;
        public const int MinPowerConst = 35;

        public const int MaxMembersConst = 10_000;

        public readonly string Name;
        
        private int members;
        private int deterrence;
        private int holiness;

        public event Action<int> OnAdoptionChanged = delegate{  };
        public event Action<int> OnTerrorChanged = delegate {  };

        public event Action<int> OnMaxAdoption = delegate { };
        public event Action<int> OnMaxTerror = delegate { };
        
        public event Action<int> OnHolinessChanged = delegate{  };
        public event Action<int> OnDeterrenceChanged = delegate {  };
        
        public event Action<int> OnMembersChanged = delegate {  };
        
        public int AdoptionReputation { get; private set; }
        public int TerrorReputation { get; private set; }

        // Благочестие.
        public int Holiness
        {
            get => holiness;
            set
            {
                if (holiness == value)
                    return;

                if (value < MinPowerConst)
                {
                    value = MinPowerConst;
                }else if (value > MaxPowerConst)
                {
                    value = MaxPowerConst;
                }

                holiness = value;
                OnHolinessChanged(holiness);
            }
        }

        // Устрашение.
        public int Deterrence
        {
            get => deterrence;
            set
            {
                if (deterrence == value)
                    return;

                if (value < MinPowerConst)
                {
                    value = MinPowerConst;
                }else if (value > MaxPowerConst)
                {
                    value = MaxPowerConst;
                }

                deterrence = value;
                OnDeterrenceChanged(deterrence);
            }
        }

        public int Members
        {
            get => members;
            set
            {
                if (members == value)
                    return;

                members = value;
                OnMembersChanged(members);
            }
        }

        public Order(string name, int members = 1)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentException();
            
            Name = name;
            Members = members;

            Holiness = MinPowerConst;
            Deterrence = MinPowerConst;
        }

        public Order(string name, int members, int adoptionReputation, int terrorReputation) : this(name, members)
        {
            AdoptionReputation = adoptionReputation;
            TerrorReputation = terrorReputation;
        }

        public void IncreaseAdoption(int value)
        {
            if (AdoptionReputation == MaxReputationConst)
                return;
            
            AdoptionReputation += value;

            if (AdoptionReputation >= MaxReputationConst)
            {
                AdoptionReputation = MaxReputationConst;
                OnMaxAdoption(AdoptionReputation);
            }

            OnAdoptionChanged(AdoptionReputation);
        }
        
        public void IncreaseTerror(int value)
        {
            if (TerrorReputation == MaxReputationConst)
                return;
            
            TerrorReputation += value;

            if (TerrorReputation >= MaxReputationConst)
            {
                TerrorReputation = MaxReputationConst;
                OnMaxTerror(TerrorReputation);
            }

            OnTerrorChanged(TerrorReputation);
        }
    }
}