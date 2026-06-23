using FlorianMan.DetailedObject.MicrowaveObject;
using UnityEngine.EventSystems;

namespace FlorianMan.Inventory.Buttons
{
    public class Butter : InventoryButton
    {
        public override void OnPointerUp(PointerEventData eventData)
        {
            if (Item == null) return;

            if (Microwave.Instance.ButterIsAtRightPosition(Item.transform.position))
            {
                InventoryManager.Instance.RemoveItem(InventoryItems.Butter);
            
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