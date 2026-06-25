using FlorianMan.DetailedObject.RecordPlayerObject;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FlorianMan.Inventory.Buttons
{
    public class VinylRecord : InventoryButton
    {
        [SerializeField] private GameObject musicVinylPrefab;
        [SerializeField] private GameObject hintVinylPrefab;
        
        [SerializeField] private Image vinylIcon;
        [SerializeField] private Sprite musicVinylSprite;
        [SerializeField] private Sprite hintVinylSprite;
        
        private bool _isHint;
        
        public void SetIsHint(bool isHint)
        {
            _isHint = isHint;
            
            prefab = isHint ? hintVinylPrefab : musicVinylPrefab;
            vinylIcon.sprite = isHint ? hintVinylSprite : musicVinylSprite;
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