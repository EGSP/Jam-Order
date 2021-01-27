using Egsp.Core.Ui;
using TMPro;
using UnityEngine;

namespace Game.Visual
{
    public class OrderMembersVisual : Visual<OrderMembersVisual>
    {
        [SerializeField] private TMP_Text membersCount;

        public void SetMembers(int value)
        {
            membersCount.text = value.ToString();
        }
    }
}