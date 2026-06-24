using FlorianMan.DetailedObject.RecordPlayerObject;
using TreeEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.LowLevel;

namespace FlorianMan.Inventory.Buttons
{
    public class VinylRecord : InventoryButton
    {
        [SerializeField] private GameObject musicVinylPrefab;
        [SerializeField] private GameObject hintVinylPrefab;
        
        private bool _isHint;
        
        public void SetIsHint(bool isHint)
        {
            _isHint = isHint;
            
            prefab = isHint ? hintVinylPrefab : musicVinylPrefab;
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            if (Item == null) return;

            if (RecordPlayer.Instance.RecordIsAtRightPosition(Item.transform.position, _isHint))
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