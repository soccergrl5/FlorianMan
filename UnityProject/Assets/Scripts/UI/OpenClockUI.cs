using FlorianMan.Inventory;
using FlorianMan.Watch;
using UnityEngine;
using UnityEngine.UI;

namespace FlorianMan.UI
{
    public class OpenClockUI : MonoBehaviour
    {
        public static OpenClockUI Instance {get; private set;}

        [SerializeField] private Button openButton;
        [SerializeField] private Button turnButton;

        private bool _clockVisible;

        private bool _openedOnce;
        private bool _firstCogwheel;
        
        private bool _openTextboxRecordPlayerArrivalSameRoom;
        private bool _openTextboxRecordPlayerArrivalOtherRoom;
        
        private void Awake()
        {
            Instance = this;
            
            openButton.onClick.AddListener(() =>
            {
                _clockVisible = !_clockVisible;

                if (_clockVisible)
                {
                    Watch.Watch.Instance.Show();
                    ShowTurnButton();

                    if (TimeManager.Instance.GetUnlockedTimes() == 1)
                    {
                        if (!_openedOnce)
                        {
                            TextBoxesUI.Instance.ActivateTextBox(TextBoxes.PocketWatchMorning1);
                            _openedOnce = true;
                        }

                        if (!_firstCogwheel && InventoryManager.Instance.InventoryContains(InventoryItems.Cogwheel1))
                        {
                            TextBoxesUI.Instance.ActivateTextBox(TextBoxes.PocketWatchMorning2);
                            _firstCogwheel = true;
                        }
                    }
                }
                else
                {
                    Watch.Watch.Instance.Hide();
                    HideTurnButton();

                    if (_openTextboxRecordPlayerArrivalSameRoom)
                    {
                        TextBoxesUI.Instance.ActivateTextBox(TextBoxes.RecordPlayerArrivalSameRoom);
                        _openTextboxRecordPlayerArrivalSameRoom = false;
                    }

                    if (_openTextboxRecordPlayerArrivalOtherRoom)
                    {
                        TextBoxesUI.Instance.ActivateTextBox(TextBoxes.RecordPlayerArrivalOtherRoom);
                        _openTextboxRecordPlayerArrivalOtherRoom = false;
                    }
                }
            });

            turnButton.onClick.AddListener(() =>
            {
                Watch.Watch.Instance.TurnClock();
            });
            
            HideTurnButton();
        }

        /// <summary>
        /// Hide the Turn Button
        /// </summary>
        private void HideTurnButton()
        {
            turnButton.gameObject.SetActive(false);
        }

        /// <summary>
        /// Show the Turn Button
        /// </summary>
        private void ShowTurnButton()
        {
            turnButton.gameObject.SetActive(true);
        }
        
        /// <summary>
        /// Hide the Open Clock UI
        /// </summary>
        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
        /// <summary>
        /// Show the Open Clock UI
        /// </summary>
        public void Show()
        {
            gameObject.SetActive(true);
        }
        
        public void ShowRecordPlayerSameRoomBoxOnClose() => _openTextboxRecordPlayerArrivalSameRoom = true;
        public void ShowRecordPlayerOtherRoomBoxOnClose() => _openTextboxRecordPlayerArrivalOtherRoom = true;
    }
}