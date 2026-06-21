using UnityEngine;
using UnityEngine.EventSystems;

namespace FlorianMan.Inventory.Buttons
{
    public class Cogwheel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private GameObject prefab;

        private GameObject item;

        /// <summary>
        /// Create the Item when the Cogwheel Inventory Button gets clicked
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerDown(PointerEventData eventData)
        {
            item = Instantiate(prefab, Camera.main.transform.position, Quaternion.identity);
        }
        
        /// <summary>
        /// Check if the Item is over a valid Position to be placed
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerUp(PointerEventData eventData)
        {
            if (item == null) return;
            
            if (Watch.Watch.Instance.CogwheelIsAtRightPosition(item.transform.position))
            {
                Destroy(item.gameObject);
                Destroy(gameObject);
            }
            else
            {
                Destroy(item.gameObject);
            }
        }
    }
}