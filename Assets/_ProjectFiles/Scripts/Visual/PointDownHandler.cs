using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Game.Visual
{
    public class PointDownHandler : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private UnityEvent onPointDown;

        public void OnPointerDown(PointerEventData eventData)
        {
            onPointDown.Invoke();            
        }
    }
}