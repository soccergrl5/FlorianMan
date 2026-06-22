using UnityEngine;

namespace FlorianMan.Fridge
{
    public class FridgeButtonCold : MonoBehaviour
    {
        public static FridgeButtonCold Instance {get; private set;}

        private bool _locked;

        private void Awake()
        {
            Instance = this;
        }

        private void OnMouseDown()
        {
            if (_locked) return;
            
            Fridge.Instance.ColdButtonPressed();
            _locked = true;
        }
        
        /// <summary>
        /// Unlock the Cold Button
        /// </summary>
        public void Unlock() => _locked = false;
        
        /// <summary>
        /// Unlock the Warm Button
        /// </summary>
        public void Lock() => _locked = true;
    }
}