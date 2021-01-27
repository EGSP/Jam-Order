using UnityEngine;

namespace Game.Visual
{
    public class OrderVisualManager : MonoBehaviour
    {
        [SerializeField] private OrderMembersVisual membersVisual;
        
        [SerializeField] private OrderReputationVisual adoptionReputationVisual;
        [SerializeField] private OrderReputationVisual holinessVisual;
        
        [SerializeField] private OrderReputationVisual terrorReputationVisual;
        [SerializeField] private OrderReputationVisual deterrenceVisual;
        
        public void Accept(Order order)
        {
            membersVisual.SetMembers(order.Members);
            order.OnMembersChanged += membersVisual.SetMembers;

            adoptionReputationVisual.MaxValue = Order.MaxReputationConst;
            holinessVisual.MaxValue = Order.MaxPowerConst;
            
            terrorReputationVisual.MaxValue = Order.MaxReputationConst;
            deterrenceVisual.MaxValue = Order.MaxPowerConst;
            
            adoptionReputationVisual.SetReputation(order.AdoptionReputation);
            holinessVisual.SetReputation(order.Holiness);
            
            terrorReputationVisual.SetReputation(order.TerrorReputation);
            deterrenceVisual.SetReputation(order.Deterrence);
            
            order.OnAdoptionChanged += adoptionReputationVisual.SetReputation;
            order.OnHolinessChanged += holinessVisual.SetReputation;
            
            order.OnTerrorChanged += terrorReputationVisual.SetReputation;
            order.OnDeterrenceChanged += deterrenceVisual.SetReputation;
        }
    }
}