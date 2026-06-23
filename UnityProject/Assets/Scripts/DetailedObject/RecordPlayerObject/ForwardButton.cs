using UnityEngine;

namespace FlorianMan.DetailedObject.RecordPlayerObject
{
    public class ForwardButton : MonoBehaviour
    {
        public static ForwardButton Instance { get; private set; }

        private bool _locked;

        private void Awake()
        {
            Instance = this;
        }

        private void OnMouseDown()
        {
            if (_locked) return;
            
            RecordPlayer.Instance.PlayForward();
            _locked = true;
        }
        
        public void Unlock() => _locked = false;
    }
}