using UnityEngine;
using UnityEngine.EventSystems;

namespace FlorianMan.Inventory.Buttons
{
    public abstract class InventoryButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] protected GameObject prefab;
        protected GameObject Item;

        /// <summary>
        /// Create the Item when Player clicks on the Button in the Inventory
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerDown(PointerEventData eventData)
        {
            Item = Instantiate(prefab, Camera.main.transform.position, Quaternion.identity);
        }
        
        /// <summary>
        /// Handle what happens with the Item when the Mouse Button is released
        /// </summary>
        /// <param name="eventData"></param>
        public abstract void OnPointerUp(PointerEventData eventData);
    }
}