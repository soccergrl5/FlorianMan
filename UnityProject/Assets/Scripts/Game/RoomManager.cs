using System;
using FlorianMan.DetailedObject.RecordPlayerObject;
using FlorianMan.DetectiveBook;
using FlorianMan.UI;
using FlorianMan.Watch;
using UnityEngine;

namespace FlorianMan.Game
{
    public class RoomManager : MonoBehaviour    
    {
        public static RoomManager Instance {get; private set;}
        
        private Rooms _currentRoom;

        private bool _noticedMissingBody;
        private bool _noticedMissingBananaPeel;

        private void Awake()
        {
            Instance = this;

            _currentRoom = Rooms.LivingRoom;

            TimeManager.Instance.OnTimeChanged += HandleTimeChanged;
        }

        private void HandleTimeChanged(object sender, EventArgs e)
        {
            if (_currentRoom != Rooms.LivingRoom) return;

            if (TimeManager.Instance.GetCurrentTime() == Times.Afternoon && !_noticedMissingBody)
            {
                OpenClockUI.Instance.ShowLivingRoomAfternoon();
                _noticedMissingBody = true;
            }
            else if (TimeManager.Instance.GetCurrentTime() == Times.Noon &&
                     ClueManager.Instance.ContainsClue(Clues.BananaPeelBehindChair) && !_noticedMissingBananaPeel)
            {
                OpenClockUI.Instance.ShowLivingRoomNoon();
                _noticedMissingBananaPeel = true;
            }
        }

        /// <summary>
        /// Change to another Room
        /// </summary>
        /// <param name="nextRoom">The Room the Person wants to enter</param>
        public void ChangeToRoom(Rooms nextRoom)
        {
            _currentRoom = nextRoom;

            CameraMovement.Instance.MoveToNewRoom(_currentRoom);
            
            RecordPlayer.Instance.RoomChanged(_currentRoom);

            if (_currentRoom != Rooms.LivingRoom) return;

            if (TimeManager.Instance.GetCurrentTime() == Times.Afternoon && !_noticedMissingBody)
            {
                TextBoxesUI.Instance.ActivateTextBox(TextBoxes.EnterLivingRoomAfternoon);
                _noticedMissingBody = true;
            }
            else if (TimeManager.Instance.GetCurrentTime() == Times.Noon &&
                     ClueManager.Instance.ContainsClue(Clues.BananaPeelBehindChair) && !_noticedMissingBananaPeel)
            {
                TextBoxesUI.Instance.ActivateTextBox(TextBoxes.EnterLivingRoomNoonKnowingBananaPeelChair);
                _noticedMissingBody = true;
            }
        }
        
        public Rooms GetCurrentRoom() => _currentRoom;
    }
}