using FlorianMan.Inventory;
using UnityEngine;

namespace FlorianMan.Fridge
{
    public class FrozenCogwheel : MonoBehaviour
    {
        public static FrozenCogwheel Instance {get; private set;}

        private bool _isFrozen = true;
        
        private void Awake()
        {
            Instance = this;
        }

        private void OnMouseDown()
        {
            if (_isFrozen) return;
            
            InventoryManager.Instance.AddItem(InventoryItems.Cogwheel);
            Destroy(gameObject);
        }
        
        /// <summary>
        /// Freeze the Cogwheel
        /// </summary>
        public void Freeze() => _isFrozen = true;
        
        /// <summary>
        /// Unfreeze the Cogwheel
        /// </summary>
        public void Unfreeze() => _isFrozen = false;
    }
}