using System;
using UnityEngine;

namespace FlorianMan.Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        public static InventoryManager Instance {get; private set;}
        
        [SerializeField] private GameObject cogwheelPrefab;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Instantiate(cogwheelPrefab, this.transform);
            Instantiate(cogwheelPrefab, this.transform);
            Instantiate(cogwheelPrefab, this.transform);
        }
    }
}