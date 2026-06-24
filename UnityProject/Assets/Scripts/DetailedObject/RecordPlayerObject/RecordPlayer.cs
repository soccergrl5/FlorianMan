using System;
using FlorianMan.Game;
using FlorianMan.Inventory;
using FlorianMan.UI;
using FlorianMan.Watch;
using UnityEngine;
using UnityEngine.UIElements;

namespace FlorianMan.DetailedObject.RecordPlayerObject
{
    public class RecordPlayer : MonoBehaviour
    {
        public static RecordPlayer Instance {get; private set;}
        
        [SerializeField]private AudioSource audioSource;
        
        [SerializeField] private AudioClip[] audioClipsMusic;
        [SerializeField] private AudioClip[] audioClipsHint;

        [SerializeField] private GameObject vinylPosition;

        private int _recordAtMorning = 0;
        private int _recordAtEvening = 1;

        private int _activeRecord; //0: No Record, 1: Music, 2: Hint

        private bool _inspectedPlayerAfterArrival;
        private bool _releasedMusicVinyl;
        private bool _placedHintRecord;
        private bool _playedHintRecordForward;
        private bool _playedHintRecordBackwards;
        
        private void Awake()
        {
            Instance = this;
            
            _activeRecord = 0;
        }

        private void Start()
        {
            TimeManager.Instance.OnTimeChanged += HandleTimeChanged;
            
            Hide();
        }
        
        private void OnDestroy()
        {
            TimeManager.Instance.OnTimeChanged -= HandleTimeChanged;
        }

        /// <summary>
        /// Show the Record Player
        /// </summary>
        public void Show()
        {
            gameObject.SetActive(true);
            
            RoomPlanUI.Instance.Hide();
            DetectiveBookUI.Instance.Hide();
            OpenClockUI.Instance.Hide();

            if (TimeManager.Instance.GetCurrentTime() == Times.Evening && !_inspectedPlayerAfterArrival)
            {
                TextBoxesUI.Instance.ActivateTextBox(TextBoxes.RecordPlayerEvening);
                _inspectedPlayerAfterArrival = true;
            }
            else if (TimeManager.Instance.GetCurrentTime() == Times.Morning)
            {
                TextBoxesUI.Instance.ActivateTextBox(TextBoxes.RecordPlayerMorning);
            }
        }

        /// <summary>
        /// Hide the Record Player
        /// </summary>
        public void Hide()
        {
            gameObject.SetActive(false);
            
            RoomPlanUI.Instance.Show();
            DetectiveBookUI.Instance.Show();
            OpenClockUI.Instance.Show();
        }

        /// <summary>
        /// Play the Record Forward
        /// </summary>
        public void PlayForward()
        {
            BackwardsButton.Instance.Unlock();

            if (_activeRecord == 0)
            {
                ForwardButton.Instance.Unlock();
                return;
            }

            audioSource.clip = _activeRecord == 1 ? audioClipsMusic[0] : audioClipsHint[0];
            audioSource.Play();
            
            CancelInvoke();
            Invoke(nameof(ReleaseForwardButton), audioSource.clip.length);
        }

        /// <summary>
        /// Play the Record Backward
        /// </summary>
        public void PlayBackward()
        {
            ForwardButton.Instance.Unlock();

            if (_activeRecord == 0)
            {
                BackwardsButton.Instance.Unlock();
                return;
            }
            
            audioSource.clip = _activeRecord == 1 ? audioClipsMusic[1] : audioClipsHint[1];
            audioSource.Play();
            
            CancelInvoke();
            Invoke(nameof(ReleaseBackwardButton), audioSource.clip.length);
        }

        /// <summary>
        /// Release the Forward Button after the Record finished Playing
        /// </summary>
        private void ReleaseForwardButton()
        {
            ForwardButton.Instance.Unlock();

            if (_activeRecord == 2 && !_playedHintRecordForward)
            {
                TextBoxesUI.Instance.ActivateTextBox(TextBoxes.CryssAngleVinylForward);
                _playedHintRecordForward = true;
            }
        }
        
        /// <summary>
        /// Release the Backward Button after the Record finished Playing
        /// </summary>
        private void ReleaseBackwardButton()
        {
            BackwardsButton.Instance.Unlock();

            if (_activeRecord == 2 && !_playedHintRecordBackwards)
            {
                TextBoxesUI.Instance.ActivateTextBox(TextBoxes.CryssAngleVinylBackwards);
                _playedHintRecordBackwards = true;
            }
        }

        /// <summary>
        /// Handle the Change of the Time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleTimeChanged(object sender, EventArgs e)
        {
            Times currentTime = TimeManager.Instance.GetCurrentTime();
            
            audioSource.Stop();

            if (currentTime == Times.Afternoon || currentTime == Times.Noon) return;
            
            _activeRecord = currentTime == Times.Morning ? _recordAtMorning : _recordAtEvening;
            
            switch (_activeRecord)
            {
                case 0:
                    ActiveRecord.Instance.RemoveRecord();
                    break;
                
                case 1:
                case 2:
                    ActiveRecord.Instance.PlaceRecord(_activeRecord);
                    PlayForward();
                    break;
            }

            if (currentTime == Times.Evening && !_inspectedPlayerAfterArrival)
            {
                if (RoomManager.Instance.GetCurrentRoom() == Rooms.Bedroom) 
                    OpenClockUI.Instance.ShowRecordPlayerSameRoomBoxOnClose();
                else
                    OpenClockUI.Instance.ShowRecordPlayerOtherRoomBoxOnClose();
            }
        }

        /// <summary>
        /// Release the Record that is in the Player
        /// </summary>
        public void ReleaseRecord()
        {
            if (_activeRecord == 0) return;
            
            audioSource.Stop();

            if (_activeRecord == 1) InventoryManager.Instance.AddItem(InventoryItems.MusicVinylRecord);

            if (_activeRecord == 2) InventoryManager.Instance.AddItem(InventoryItems.HintVinylRecord);
            
            ForwardButton.Instance.Unlock();
            BackwardsButton.Instance.Unlock();
            
            Times currentTime = TimeManager.Instance.GetCurrentTime();
            if (currentTime == Times.Morning) _recordAtMorning = 0;
            else if (currentTime == Times.Evening)
            {
                if (_activeRecord == 1)
                    _recordAtEvening = 0;
                else if (InventoryManager.Instance.InventoryContains(InventoryItems.MusicVinylRecord))
                    _recordAtEvening = 0;
                else if (_recordAtMorning == 1) _recordAtEvening = 0;
                else _recordAtEvening = 1;
            }
            
            _activeRecord = 0;

            if (currentTime == Times.Evening && !_releasedMusicVinyl)
            {
                TextBoxesUI.Instance.ActivateTextBox(TextBoxes.MusicVinylOut);
                _releasedMusicVinyl = true;
            }
        }

        /// <summary>
        /// Check if the Record Item is on the Right Position to be Placed in the Player
        /// </summary>
        /// <param name="position">Position of the Record Item</param>
        /// <param name="isHintRecord">Is the Record the Hint Record or not (Music Record)</param>
        /// <returns>True if the Position is valid, False otherwise</returns>
        public bool RecordIsAtRightPosition(Vector3 position, bool isHintRecord)
        {
            if (!gameObject.activeSelf) return false;
            if (ActiveRecord.Instance.gameObject.activeSelf) return false;
            
            Vector3 positionRecord = vinylPosition.transform.position;
            float radius           = 1f;

            if (position.x < positionRecord.x + radius
                && position.x > positionRecord.x - radius
                && position.y < positionRecord.y + radius
                && position.y > positionRecord.y - radius)
            {
                _activeRecord = isHintRecord ? 2 : 1;
                ActiveRecord.Instance.PlaceRecord(_activeRecord);
                CreateAccordingRecordHistory();

                if (_activeRecord == 2 && !_placedHintRecord)
                {
                    TextBoxesUI.Instance.ActivateTextBox(TextBoxes.CryssAngleVinylIn);
                    _placedHintRecord = true;
                }
                
                return true;
            }

            return false;
        }

        /// <summary>
        /// Create the according History for which Record is laying on the Record Player
        /// </summary>
        private void CreateAccordingRecordHistory()
        {
            Times time = TimeManager.Instance.GetCurrentTime();
            
            if (time == Times.Evening) _recordAtEvening = _activeRecord;
            else if (time == Times.Morning) _recordAtMorning = _activeRecord;
        }
    }
}