using UnityEngine;
using UnityEngine.EventSystems;

namespace FlorianMan.Inventory.Buttons
{
    public class Cogwheel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private GameObject prefab;

        private GameObject item;

        public void OnPointerDown(PointerEventData eventData)
        {
            item = Instantiate(prefab, Camera.main.transform.position, Quaternion.identity);
        }
        
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