using UnityEngine;

namespace FlorianMan.Telephone
{
    public class TelephoneBackground : MonoBehaviour
    {
        public static TelephoneBackground Instance {get; private set;}

        private bool _locked;
        
        private void Awake()
        {
            Instance = this;
        }

        private void OnMouseDown()
        {
            if (_locked) return;
            
            Telephone.Instance.Hide();
        }
        
        /// <summary>
        /// Lock the Close Button
        /// </summary>
        public void Lock() => _locked = true;
        
        /// <summary>
        /// Unlock the Close Button
        /// </summary>
        public void Unlock() => _locked = false;
    }
}