using UnityEngine;

namespace FlorianMan.DetailedObject.FridgeObject
{
    public class FridgeButtonWarm : MonoBehaviour
    {
        public static FridgeButtonWarm Instance {get; private set;}

        private bool _locked;

        private void Awake()
        {
            Instance = this;
        }

        private void OnMouseDown()
        {
            if (_locked) return;
            
            Fridge.Instance.WarmButtonPressed();
            _locked = true;
        }
        
        /// <summary>
        /// Unlock the Warm Button
        /// </summary>
        public void Unlock() => _locked = false;
        
        /// <summary>
        /// Lock the Warm Button
        /// </summary>
        public void Lock() => _locked = false;
    }
}