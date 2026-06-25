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
        
        private bool _openTextboxRecordPlayerArrivalSameRoom;
        private bool _openTextboxRecordPlayerArrivalOtherRoom;
        private bool _openTextboxLivingRoomAfternoon;
        private bool _openTextboxLivingRoomNoon;
        
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
                        if (!TextBoxesUI.Instance.CheckIfTextWasShown(TextBoxes.PocketWatchMorning2) &&
                            !TextBoxesUI.Instance.CheckIfTextWasShown(TextBoxes.PocketWatchMorning3) &&
                            !InventoryManager.Instance.InventoryContains(InventoryItems.Cogwheel1))
                        {
                            TextBoxesUI.Instance.ActivateTextBox(TextBoxes.PocketWatchMorning1);
                        }
                        else if (!TextBoxesUI.Instance.CheckIfTextWasShown(TextBoxes.PocketWatchMorning1) &&
                                 InventoryManager.Instance.InventoryContains(InventoryItems.Cogwheel1))
                        {
                            TextBoxesUI.Instance.ActivateTextBox(TextBoxes.PocketWatchMorning3);
                        }
                        else if (TextBoxesUI.Instance.CheckIfTextWasShown(TextBoxes.PocketWatchMorning1) &&
                                 InventoryManager.Instance.InventoryContains(InventoryItems.Cogwheel1))
                        {
                            TextBoxesUI.Instance.ActivateTextBox(TextBoxes.PocketWatchMorning2);
                        }
                    }
                }
                else
                {
                    Watch.Watch.Instance.Hide();
                    HideTurnButton();

                    if (_openTextboxRecordPlayerArrivalSameRoom && TimeManager.Instance.GetCurrentTime() == Times.Evening)
                    {
                        TextBoxesUI.Instance.ActivateTextBox(TextBoxes.RecordPlayerArrivalSameRoom);
                        _openTextboxRecordPlayerArrivalSameRoom = false;
                    }

                    if (_openTextboxRecordPlayerArrivalOtherRoom && TimeManager.Instance.GetCurrentTime() == Times.Evening)
                    {
                        TextBoxesUI.Instance.ActivateTextBox(TextBoxes.RecordPlayerArrivalOtherRoom);
                        _openTextboxRecordPlayerArrivalOtherRoom = false;
                    }

                    if (_openTextboxLivingRoomAfternoon && TimeManager.Instance.GetCurrentTime() == Times.Afternoon)
                    {
                        TextBoxesUI.Instance.ActivateTextBox(TextBoxes.EnterLivingRoomAfternoon);
                        _openTextboxLivingRoomAfternoon = false;
                    }

                    if (_openTextboxLivingRoomNoon && TimeManager.Instance.GetCurrentTime() == Times.Noon)
                    {
                        TextBoxesUI.Instance.ActivateTextBox(TextBoxes.EnterLivingRoomNoonKnowingBananaPeelChair);
                        _openTextboxLivingRoomNoon = false;
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
        public void ShowLivingRoomAfternoon() => _openTextboxLivingRoomAfternoon = true;
        public void ShowLivingRoomNoon() => _openTextboxLivingRoomNoon = true;

        public void Disable()
        {
            openButton.interactable = false;
            turnButton.interactable = false;
        }

        public void Enable()
        {
            openButton.interactable = true;
            turnButton.interactable = true;
        }
    }
}