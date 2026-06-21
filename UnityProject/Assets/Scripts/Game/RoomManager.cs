using UnityEngine;

namespace FlorianMan.Game
{
    public class RoomManager : MonoBehaviour    
    {
        public static RoomManager Instance {get; private set;}
        
        private Rooms _currentRoom;

        private void Awake()
        {
            Instance = this;

            _currentRoom = Rooms.LivingRoom;
        }
        
        /// <summary>
        /// Change to another Room
        /// </summary>
        /// <param name="nextRoom">The Room the Person wants to enter</param>
        public void ChangeToRoom(Rooms nextRoom)
        {
            _currentRoom = nextRoom;

            CameraMovement.Instance.MoveToNewRoom(_currentRoom);
        }
    }
}