using UnityEngine;

namespace FlorianMan.DetailedObject.RecordPlayerObject
{
    public class BackwardsButton : MonoBehaviour
    {
        public static BackwardsButton Instance { get; private set; }

        private bool _locked;
        
        private void Awake()
        {
            Instance = this;
        }

        private void OnMouseDown()
        {
            if (_locked) return;
            
            RecordPlayer.Instance.PlayBackward();
            _locked = true;
        }
        
        public void Unlock() => _locked = false;
    }
}