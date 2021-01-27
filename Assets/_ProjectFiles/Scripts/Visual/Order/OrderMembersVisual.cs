using Egsp.Core.Ui;
using TMPro;
using UnityEngine;

namespace Game.Visuals
{
    public class OrderMembersVisual : Visual
    {
        [SerializeField] private TMP_Text membersCount;

        public void SetMembers(int value)
        {
            membersCount.text = value.ToString();
        }
    }
}