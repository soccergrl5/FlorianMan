using UnityEngine;

namespace FlorianMan.DetailedObject.MicrowaveObject
{
    public class MicrowaveDoor : MonoBehaviour
    {
        [SerializeField] private GameObject door;
        [SerializeField] private GameObject doorOpen;
        
        public static MicrowaveDoor Instance {get; private set;}
        
        private bool _doorIsOpen;
        private bool _locked;

        private void Awake()
        {
            Instance = this;
        }

        private void OnMouseDown()
        {
            if (_locked) return;
            
            _doorIsOpen = !_doorIsOpen;
            
            door.SetActive(!_doorIsOpen);
            doorOpen.SetActive(_doorIsOpen);
            
            if (_doorIsOpen) Microwave.Instance.PlayOpenSound();
            else Microwave.Instance.PlayCloseSound();
        }
        
        public bool DoorIsOpen() => _doorIsOpen;
        
        /// <summary>
        /// Lock the Door of the Microwave
        /// </summary>
        public void LockDoor() => _locked = true;
        
        /// <summary>
        /// Unlock the Door of the Microwave
        /// </summary>
        public void UnlockDoor() => _locked = false;
    }
}