using UnityEngine.EventSystems;

namespace FlorianMan.Inventory.Buttons
{
    public class VinylRecord : InventoryButton
    {
        public override void OnPointerUp(PointerEventData eventData)
        {
            if (Item == null) return;
            
            InventoryManager.Instance.RemoveItem(InventoryItems.VinylRecord);
            
            Destroy(Item.gameObject);
            Destroy(gameObject);
        }
    }
}