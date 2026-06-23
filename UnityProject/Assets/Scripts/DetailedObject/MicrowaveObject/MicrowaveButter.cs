using FlorianMan.Inventory;
using UnityEngine;

namespace FlorianMan.DetailedObject.MicrowaveObject
{
    public class MicrowaveButter : MonoBehaviour
    {
        public static MicrowaveButter Instance {get; private set;}

        private bool _microwaved;

        private void Awake()
        {
            Instance = this;
            
            Hide();
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        private void OnMouseDown()
        {
            InventoryManager.Instance.AddItem(_microwaved ? InventoryItems.Cogwheel : InventoryItems.Butter);
            
            Hide();
        }
        
        public void Microwaved() => _microwaved = true;
    }
}