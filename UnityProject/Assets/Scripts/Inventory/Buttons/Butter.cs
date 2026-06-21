using UnityEngine.EventSystems;

namespace FlorianMan.Inventory.Buttons
{
    public class Butter : InventoryButton
    {
        public override void OnPointerUp(PointerEventData eventData)
        {
            if (Item == null) return;
            
            InventoryManager.Instance.RemoveItem(InventoryItems.Butter);
            
            Destroy(Item.gameObject);
            Destroy(gameObject);
        }
    }
}