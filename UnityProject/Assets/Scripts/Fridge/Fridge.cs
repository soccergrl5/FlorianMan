using System.Collections.Generic;
using FlorianMan.UI;
using FlorianMan.Watch;
using UnityEngine;

namespace FlorianMan.Fridge
{
    public class Fridge : MonoBehaviour
    {
        public static Fridge Instance {get; private set;}

        [SerializeField] private GameObject doorOpen;
        [SerializeField] private GameObject doorClose;
        
        private readonly List<bool> _isColdList = new ();
        private readonly List<bool> _setColdList = new();
        
        private bool _doorIsOpen;

        private void Awake()
        {
            Instance = this;
            
            _setColdList.Add(true);
            _setColdList.Add(true);
            _setColdList.Add(true);
            _setColdList.Add(true);
            
            _isColdList.Add(true);
            _isColdList.Add(true);
            _isColdList.Add(true);
            _isColdList.Add(true);
        }

        private void Start()
        {
            Hide();
        }

        /// <summary>
        /// Hide the Fridge
        /// </summary>
        public void Hide()
        {
            gameObject.SetActive(false);
            
            RoomPlanUI.Instance.Enable();
            DetectiveBookUI.Instance.Enable();
            OpenClockUI.Instance.Enable();
        }

        /// <summary>
        /// Show the Fridge
        /// </summary>
        public void Show()
        {
            gameObject.SetActive(true);
            
            RoomPlanUI.Instance.Disable();
            DetectiveBookUI.Instance.Disable();
            OpenClockUI.Instance.Disable();
            
            CheckFridgeSettings();
        }

        /// <summary>
        /// Chech the Settings the Fridge currently has
        /// </summary>
        private void CheckFridgeSettings()
        {
            Times time = TimeManager.Instance.GetCurrentTime();

            if (_setColdList[(int)time])
            {
                FridgeButtonCold.Instance.Lock();
                FridgeButtonWarm.Instance.Unlock();
            }
            else
            {
                FridgeButtonWarm.Instance.Lock();
                FridgeButtonCold.Instance.Unlock();
            }
            
            if (_isColdList[(int)time]) FridgeInside.Instance.ColdInside();
            else FridgeInside.Instance.WarmInside();
        }
        
        /// <summary>
        /// Interaction with the Fridge Door
        /// </summary>
        public void DoorInteraction()
        {
            _doorIsOpen = !_doorIsOpen;
            
            if (_doorIsOpen) doorOpen.SetActive(true);
            else doorClose.SetActive(true);
        }

        /// <summary>
        /// Cold Button on the Fridge is Pressed
        /// </summary>
        public void WarmButtonPressed()
        {
            FridgeButtonCold.Instance.Unlock();

            Times time = TimeManager.Instance.GetCurrentTime();

            switch (time)
            {
                case Times.Noon:
                    _isColdList[0] = false;
                    _isColdList[1] = false;
                    _isColdList[2] = false;

                    _setColdList[0] = false;
                    _setColdList[1] = false;
                    _setColdList[2] = false;
                    _setColdList[3] = false;
                    break;
                    
                case Times.Afternoon:
                    _isColdList[0] = false;
                    _isColdList[1] = false;
                    
                    _setColdList[0] = false;
                    _setColdList[1] = false;
                    _setColdList[2] = false;
                    break;
                    
                case Times.Evening:
                    _isColdList[0] = false;
                    
                    _setColdList[0] = false;
                    _setColdList[1] = false;
                    break;
                
                case Times.Morning:
                    _setColdList[0] = false;
                    break;
            }
        }

        /// <summary>
        /// Warm Button on the Fridge is Pressed
        /// </summary>
        public void ColdButtonPressed()
        {
            FridgeButtonWarm.Instance.Unlock();
            
            Times time = TimeManager.Instance.GetCurrentTime();

            switch (time)
            {
                case Times.Noon:
                    _isColdList[0] = true;
                    _isColdList[1] = true;
                    _isColdList[2] = true;

                    _setColdList[0] = true;
                    _setColdList[1] = true;
                    _setColdList[2] = true;
                    _setColdList[3] = true;
                    break;

                case Times.Afternoon:
                    _isColdList[0] = true;
                    _isColdList[1] = true;

                    _setColdList[0] = true;
                    _setColdList[1] = true;
                    _setColdList[2] = true;
                    break;

                case Times.Evening:
                    _isColdList[0] = true;

                    _setColdList[0] = true;
                    _setColdList[1] = true;
                    break;

                case Times.Morning:
                    _setColdList[0] = true;
                    break;
            }
        }
    }
}