using FlorianMan.Inventory;
using UnityEngine;

namespace FlorianMan.DetailedObject.FridgeObject
{
    public class FrozenCogwheel : MonoBehaviour
    {
        public static FrozenCogwheel Instance {get; private set;}
        
        [SerializeField] private Sprite cogwheelSprite;

        private bool _isFrozen = true;
        
        private void Awake()
        {
            Instance = this;
        }

        private void OnMouseDown()
        {
            if (_isFrozen) return;
            
            InventoryManager.Instance.AddItem(InventoryItems.Cogwheel2);
            Destroy(gameObject);
        }
        
        /// <summary>
        /// Freeze the Cogwheel
        /// </summary>
        public void Freeze()
        {
            _isFrozen = true;
            GetComponent<SpriteRenderer>().sprite = null;
        }

        /// <summary>
        /// Unfreeze the Cogwheel
        /// </summary>
        public void Unfreeze()
        {
            _isFrozen = false;
            GetComponent<SpriteRenderer>().sprite = cogwheelSprite;
        }
    }
}