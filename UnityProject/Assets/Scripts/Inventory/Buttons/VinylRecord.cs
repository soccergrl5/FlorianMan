using UnityEngine.EventSystems;

namespace FlorianMan.Inventory.Buttons
{
    public class VinylRecord : InventoryButton
    {
        private bool _isHint;
        
        public void SetIsHint(bool isHint) => _isHint = isHint;
        
        public override void OnPointerUp(PointerEventData eventData)
        {
            if (Item == null) return;
            
            InventoryManager.Instance.RemoveItem(InventoryItems.MusicVinylRecord);
            
            Destroy(Item.gameObject);
            Destroy(gameObject);
        }
    }
}