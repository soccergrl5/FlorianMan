using UnityEngine;

namespace FlorianMan.DetailedObject.MicrowaveObject
{
    public class MicrowaveStart : MonoBehaviour
    {
        public static MicrowaveStart Instance {get; private set;}

        private bool _locked;

        private void Awake()
        {
            Instance = this;
        }

        private void OnMouseDown()
        {
            if (_locked) return;
            if(MicrowaveDoor.Instance.DoorIsOpen()) return;
            
            Microwave.Instance.StartMicrowave();
        }
        
        public void Lock() => _locked = true;
        
        public void Unlock() => _locked = false;
    }
}