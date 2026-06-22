using System;
using FlorianMan.Inventory;
using FlorianMan.UI;
using UnityEngine;

namespace FlorianMan.RecordPlayer
{
    public class RecordPlayer : MonoBehaviour
    {
        public static RecordPlayer Instance {get; private set;}

        private int _activeRecord; //0: No Record, 1: Music, 2: Hint

        private void Awake()
        {
            Instance = this;
            
            _activeRecord = 0;
        }

        private void Start()
        {
            Hide();
        }

        public void Show()
        {
            gameObject.SetActive(true);
            
            RoomPlanUI.Instance.Disable();
            DetectiveBookUI.Instance.Disable();
            OpenClockUI.Instance.Disable();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            
            RoomPlanUI.Instance.Enable();
            DetectiveBookUI.Instance.Enable();
            OpenClockUI.Instance.Enable();
        }

        public void PlayForward()
        {
            BackwardsButton.Instance.Unlock();

            if (_activeRecord == 0)
            {
                ForwardButton.Instance.Unlock();
                return;
            }
            
            Debug.Log("Playing Forward " + _activeRecord);
        }

        public void PlayBackward()
        {
            ForwardButton.Instance.Unlock();

            if (_activeRecord == 0)
            {
                BackwardsButton.Instance.Unlock();
                return;
            }
            
            Debug.Log("Playing Backward " + _activeRecord);
        }

        public void ReleaseRecord()
        {
            if (_activeRecord == 0) return;
            
            if (_activeRecord == 1) InventoryManager.Instance.AddItem(InventoryItems.MusicVinylRecord);
            if (_activeRecord == 2) InventoryManager.Instance.AddItem(InventoryItems.HintVinylRecord);
            
            ForwardButton.Instance.Unlock();
            BackwardsButton.Instance.Unlock();
            
            _activeRecord = 0;
        }

        public bool RecordIsAtRightPosition(Vector3 position, bool isHintRecord)
        {
            if (!gameObject.activeSelf) return false;
            if (ActiveRecord.Instance.gameObject.activeSelf) return false;
            
            Vector3 positionRecord = ActiveRecord.Instance.gameObject.transform.position;
            float radius           = 1f;

            if (position.x < positionRecord.x + radius
                && position.x > positionRecord.x - radius
                && position.y < positionRecord.y + radius
                && position.y > positionRecord.y - radius)
            {
                _activeRecord = isHintRecord ? 2 : 1;
                ActiveRecord.Instance.PlaceRecord();

                return true;
            }

            return false;
        }
    }
}