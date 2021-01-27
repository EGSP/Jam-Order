using System;
using Egsp.Core.Ui;
using TMPro;
using UnityEngine;

namespace Game.Visuals
{
    public class DayTimerVisualController : MonoBehaviour
    {
        [SerializeField] private TMP_Text daysCountText;
        [SerializeField] private DayTimer dayTimer;
        
        private void Start()
        {
            if (dayTimer == null)
            {
                Debug.LogWarning("Не подключен таймер дней к UI!");
            }
            else
            {
                PrintDays(dayTimer.Days);
                dayTimer.OnDayChanged += PrintDays;
            }

        }

        private void PrintDays(int days)
        {
            daysCountText.text = days.ToString();
        }
    }
}