using FlorianMan.UI;
using UnityEngine;

namespace FlorianMan.Telephone
{
    public class Telephone : MonoBehaviour
    {
        public static Telephone Instance {get; private set;}
        
        private AudioSource _audioSource;

        private string _dialedNumber;

        private void Awake()
        {
            Instance = this;
            
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            Hide();
        }

        /// <summary>
        /// Show the Telephone
        /// </summary>
        public void Show()
        {
            gameObject.SetActive(true);
            
            RoomPlanUI.Instance.Disable();
            DetectiveBookUI.Instance.Disable();
            OpenClockUI.Instance.Disable();
            
            TurnablePart.Instance.UnlockTelephone();
        }

        /// <summary>
        /// Hide the Telephone
        /// </summary>
        public void Hide()
        {
            _dialedNumber = "";
            
            gameObject.SetActive(false);
            
            RoomPlanUI.Instance.Enable();
            DetectiveBookUI.Instance.Enable();
            OpenClockUI.Instance.Enable();
        }

        public void AddDial(string number)
        {
            _dialedNumber += number;

            if (_dialedNumber == "811")
            {
                TurnablePart.Instance.LockTelephone();
                TelephoneBackground.Instance.Lock();
                
                float duration = _audioSource.clip.length;
                Invoke(nameof(UnlockTurnablePart), duration);
                
                _audioSource.Play();
                
                _dialedNumber = "";
            }
        }

        private void UnlockTurnablePart()
        {
            TurnablePart.Instance.UnlockTelephone();
            TelephoneBackground.Instance.Unlock();
        }
    }
}