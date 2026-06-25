using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FlorianMan.Inventory.Buttons
{
    public class Cogwheel : InventoryButton
    {
        [SerializeField] private GameObject[] cogwheelPrefabs;
        
        [SerializeField] private Image cogwheelIcon;
        [SerializeField] private Sprite[] cogwheelSprites;
        
        private int _cogwheelNumber;
        
        public override void OnPointerUp(PointerEventData eventData)
        {
            if (Item == null) return;
            
            //If the Position the Cogwheel was released is valid put it there
            //otherwise keep it in the Inventory
            if (Watch.Watch.Instance.CogwheelIsAtRightPosition(Item.transform.position, _cogwheelNumber))
            {
                InventoryManager.Instance.RemoveItem(InventoryItems.Cogwheel1);
                
                Destroy(Item.gameObject);
                Destroy(gameObject);
            }
            else
            {
                Destroy(Item.gameObject);
            }
        }
        
        public void SetCogwheelNumber(int cogwheelNumber)
        {
            _cogwheelNumber = cogwheelNumber;
            
            prefab              = cogwheelPrefabs[_cogwheelNumber - 1];
            cogwheelIcon.sprite = cogwheelSprites[_cogwheelNumber - 1];
        }
    }
}