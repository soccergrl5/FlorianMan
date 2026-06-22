using System;
using System.Collections.Generic;
using FlorianMan.Inventory.Buttons;
using UnityEngine;
using UnityEngine.Serialization;

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
                    Instantiate(cogwheelPrefab, transform);
                    break;
                
                case InventoryItems.Butter:
                    Instantiate(butterPrefab, transform);
                    break;
                
                case InventoryItems.MusicVinylRecord:
                    GameObject musicVinyl = Instantiate(vinylRecordPrefab, transform);
                    musicVinyl.GetComponent<VinylRecord>().SetIsHint(false);
                    break;
                
                case InventoryItems.HintVinylRecord:
                    GameObject hintVinyl = Instantiate(vinylRecordPrefab, transform);
                    hintVinyl.GetComponent<VinylRecord>().SetIsHint(true);
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