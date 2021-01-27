using Egsp.Core;
using Egsp.RandomTools;
using UnityEngine;

namespace Game.Towns
{
    public enum TownSize
    {
        Big,
        Medium,
        Small
    }
    
    public class Town
    {
        public TownSize TownSize { get; }

        public Town(TownSize townSize)
        {
            TownSize = townSize;
        }
    }

    public class TownFactory : SerializedSingleton<TownFactory>
    {
        [SerializeField] private float smallWeight;
        [SerializeField] private float mediumWeight;
        [SerializeField] private float bigWeight;
        
        private WeightedList<TownSize> townSizeRandom;

        protected override void Awake()
        {
            base.Awake();
            
            townSizeRandom = new WeightedList<TownSize>();
            townSizeRandom.Add(new WeightedItem<TownSize>(TownSize.Small, smallWeight));
            townSizeRandom.Add(new WeightedItem<TownSize>(TownSize.Medium, mediumWeight));
            townSizeRandom.Add(new WeightedItem<TownSize>(TownSize.Big, bigWeight));
        }

        private TownSize GetRandomSize()
        {
            return townSizeRandom.Pick().Value;
        }
    }
}