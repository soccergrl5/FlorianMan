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
        
        [SerializeField] private AudioClip cogwheelSound;

        private AudioSource _audioSource;
        
        private List<InventoryItems> _items = new ();
        
        private void Awake()
        {
            Instance = this;
            
            _audioSource = GetComponent<AudioSource>();
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
                case InventoryItems.Cogwheel1:
                    GameObject cogwheel1 = Instantiate(cogwheelPrefab, transform);
                    cogwheel1.GetComponent<Cogwheel>().SetCogwheelNumber(1);
                    
                    _audioSource.PlayOneShot(cogwheelSound);
                    break;
                
                case InventoryItems.Cogwheel2:
                    GameObject cogwheel2 = Instantiate(cogwheelPrefab, transform);
                    cogwheel2.GetComponent<Cogwheel>().SetCogwheelNumber(2);
                    
                    _audioSource.PlayOneShot(cogwheelSound);
                    break;
                
                case InventoryItems.Cogwheel3:
                    GameObject cogwheel3 = Instantiate(cogwheelPrefab, transform);
                    cogwheel3.GetComponent<Cogwheel>().SetCogwheelNumber(3);
                    
                    _audioSource.PlayOneShot(cogwheelSound);
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