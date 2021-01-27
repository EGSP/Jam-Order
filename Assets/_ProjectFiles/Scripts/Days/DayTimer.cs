using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Game
{
    public class DayTimer : SerializedMonoBehaviour
    {
        [SerializeField] private int days;
        [SerializeField] private float secondsPerDay;
        [SerializeField] private float defaultTimeFactor = 1;

        private bool _started;
        
        [ReadOnly][OdinSerialize]
        public int Days { get; set; }

        [ReadOnly][OdinSerialize]
        public float DayTime { get; set; }
        
        [ReadOnly][OdinSerialize]
        public float TimeFactor { get; set; }

        /// <summary>
        /// В отличии от OnDayEnded, вызывается и при событии истечения всех дней.
        /// </summary>
        public event Action<int> OnDayChanged = delegate {  };
        /// <summary>
        /// Вызывается при завершении дня.
        /// </summary>
        public event Action OnDayEnded = delegate {  };
        /// <summary>
        /// Вызывается при истечении всех дней.
        /// </summary>
        public event Action OnDaysExpired = delegate {  };

        private void Update()
        {
            if (_started)
            {
                Count();
            }
        }

        private void Count()
        {
            if (Days == 0)
                return;
            
            DayTime -= Time.deltaTime * TimeFactor;
            // День закончился.
            if (DayTime <= 0)
            {
                ReduceDay();
            }
        }

        private void ReduceDay()
        {
            Days--;
            
            OnDayChanged(Days);

            // Дни закончились.
            if (Days == 0)
            {
                OnDaysExpired();
            }
            else
            {
                DayTime = secondsPerDay;
                OnDayEnded();
            }
        }

        public void StartTimer()
        {
            _started = true;
            ResetTimer();
        }

        public void ResetTimer()
        {
            Days = days;
            DayTime = secondsPerDay;
            ResetTimeFactor();
        }

        public void ResetTimeFactor()
        {
            TimeFactor = defaultTimeFactor;
        }

        public void SkipDay()
        {
            if (Days == 0)
                return;

            ReduceDay();
        }
    }
}