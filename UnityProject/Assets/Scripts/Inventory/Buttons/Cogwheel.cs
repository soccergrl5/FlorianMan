using UnityEngine.EventSystems;

namespace FlorianMan.Inventory.Buttons
{
    public class Cogwheel : InventoryButton
    {
        public override void OnPointerUp(PointerEventData eventData)
        {
            if (Item == null) return;
            
            //If the Position the Cogwheel was released is valid put it there
            //otherwise keep it in the Inventory
            if (Watch.Watch.Instance.CogwheelIsAtRightPosition(Item.transform.position))
            {
                InventoryManager.Instance.RemoveItem(InventoryItems.Cogwheel);
                
                Destroy(Item.gameObject);
                Destroy(gameObject);
            }
            else
            {
                Destroy(Item.gameObject);
            }
        }
    }
}