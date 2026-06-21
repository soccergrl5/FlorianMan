using System.Collections.Generic;
using UnityEngine;

namespace FlorianMan.Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        public static InventoryManager Instance {get; private set;}
        
        [SerializeField] private GameObject cogwheelPrefab;
        [SerializeField] private GameObject butterPrefab;
        [SerializeField] private GameObject vinylRecordPrefab;

        private List<InventoryItems> _items = new ();
        
        private void Awake()
        {
            Instance = this;
        }

        /// <summary>
        /// Add an Item to the Inventory
        /// </summary>
        /// <param name="item">Type of Item that gets added</param>
        public void AddItem(InventoryItems item)
        {
            _items.Add(item);
            
            switch (item)
            {
                case InventoryItems.Cogwheel:
                    Instantiate(cogwheelPrefab);
                    break;
                
                case InventoryItems.Butter:
                    Instantiate(butterPrefab);
                    break;
                
                case InventoryItems.VinylRecord:
                    Instantiate(vinylRecordPrefab);
                    break;
            }
        }
        
        /// <summary>
        /// Remove an Item from the Inventory
        /// </summary>
        /// <param name="item">Item that is removed from the Inventory</param>
        public void RemoveItem(InventoryItems item)
        {
            _items.Remove(item);
        }
    }
}