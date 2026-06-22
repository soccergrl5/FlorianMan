using TreeEditor;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.LowLevel;

namespace FlorianMan.Inventory.Buttons
{
    public class VinylRecord : InventoryButton
    {
        private bool _isHint;
        
        public void SetIsHint(bool isHint) => _isHint = isHint;
        
        public override void OnPointerUp(PointerEventData eventData)
        {
            if (Item == null) return;

            if (RecordPlayer.RecordPlayer.Instance.RecordIsAtRightPosition(Item.transform.position, _isHint))
            {
                InventoryManager.Instance.RemoveItem(InventoryItems.MusicVinylRecord);
            
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