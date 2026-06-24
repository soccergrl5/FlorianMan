using System;
using FlorianMan.DetectiveBook;
using FlorianMan.UI;
using FlorianMan.Watch;
using UnityEngine;

namespace FlorianMan.DetailedObject.TelephoneObject
{
    public class Telephone : MonoBehaviour
    {
        public static Telephone Instance {get; private set;}

        [SerializeField] private AudioClip call811;
        [SerializeField] private AudioClip circularSawHint;
        [SerializeField] private AudioClip ringing;
        
        [SerializeField] private AudioSource audioSource;

        private string _dialedNumber = "";
        
        private bool _phoneRingedAfternoon = false;
        private bool _phoneRingingAfternoon = false;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Hide();

            TimeManager.Instance.OnTimeChanged += HandleTimeChaged;
        }

        /// <summary>
        /// Show the Telephone
        /// </summary>
        public void Show()
        {
            gameObject.SetActive(true);
            
            RoomPlanUI.Instance.Hide();
            DetectiveBookUI.Instance.Hide();
            OpenClockUI.Instance.Hide();
            PauseUI.Instance.Hide();
            HintUI.Instance.Hide();
            
            CloseDetailViewUI.Instance.OpenCloseButton(DetailedObjects.Telephone);

            if (_phoneRingingAfternoon)
            {
                TurnablePart.Instance.LockTelephone();
                CloseDetailViewUI.Instance.LockButton();

                audioSource.clip = circularSawHint;
                audioSource.loop = false;
                
                SubtitlesUI.Instance.ShowSubtitles(Subtitles.CallCircularSaw);
                
                Invoke(nameof(UnlockTurnablePart), 6.7f);
                
                audioSource.Play();
                
                return;
            }
            
            TurnablePart.Instance.UnlockTelephone();
            
            if (TimeManager.Instance.GetCurrentTime() != Times.Morning)
                TextBoxesUI.Instance.ActivateTextBox(TextBoxes.OldTelephoneMurderDay);
            else if (!ClueManager.Instance.ContainsClue(Clues.EmergencyNoteUnderShelf))
                TextBoxesUI.Instance.ActivateTextBox(TextBoxes.OldTelephoneMorning);
        }

        /// <summary>
        /// Hide the Telephone
        /// </summary>
        public void Hide()
        {
            _dialedNumber = "";
            
            gameObject.SetActive(false);
            
            RoomPlanUI.Instance.Show();
            DetectiveBookUI.Instance.Show();
            OpenClockUI.Instance.Show();
            PauseUI.Instance.Show();
            HintUI.Instance.Show();
        }

        /// <summary>
        /// Add the Dial to the Number to call
        /// </summary>
        /// <param name="number">Dial to add</param>
        public void AddDial(string number)
        {
            _dialedNumber += number;

            if (_dialedNumber == "811")
            {
                TurnablePart.Instance.LockTelephone();
                CloseDetailViewUI.Instance.LockButton();
                
                audioSource.clip = call811;
                
                Invoke(nameof(UnlockTurnablePart), 29.0f);
                SubtitlesUI.Instance.ShowSubtitles(Subtitles.Call811);
                
                audioSource.Play();
                
                _dialedNumber = "";
            }
        }

        /// <summary>
        /// Unlock the Turnable Part after a call
        /// </summary>
        private void UnlockTurnablePart()
        {
            TurnablePart.Instance.UnlockTelephone();
            CloseDetailViewUI.Instance.UnlockButton();

            if (_phoneRingingAfternoon)
            {
                _phoneRingingAfternoon = false;
                _phoneRingedAfternoon = true;
                
                TextBoxesUI.Instance.ActivateTextBox(TextBoxes.TelephoneResponse);
            }
        }

        private void HandleTimeChaged(object sender, EventArgs e)
        {
            if (TimeManager.Instance.GetCurrentTime() != Times.Afternoon)
            {
                audioSource.Stop();
                CancelInvoke();
                return;
            }
            
            if (_phoneRingedAfternoon) return;
            
            Invoke(nameof(RingPhone), 10f);
        }

        /// <summary>
        /// Ring the Phone in the Afternoon
        /// </summary>
        private void RingPhone()
        {
            _phoneRingingAfternoon = true;
            
            TextBoxesUI.Instance.ActivateTextBox(TextBoxes.TelephoneRinging);
            
            audioSource.clip = ringing;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}