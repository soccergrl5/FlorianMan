using FlorianMan.Game;
using FlorianMan.Watch;
using UnityEngine;

namespace FlorianMan
{
    public class CameraMovement : MonoBehaviour
    {
        public static CameraMovement Instance {get; private set;}
        
        private int _currentPositionX;
        
        private const int LivingRoomPosition = 0;
        private const int KitchenPosition = 25;
        private const int BedroomPosition = 50;
        private const int BasementPosition = 75;

        private void Awake()
        {
            Instance = this;

            _currentPositionX = LivingRoomPosition;
        }
        
        private void MoveToCurrentPosition()
        {
            transform.SetPositionAndRotation(new Vector3(_currentPositionX, 0, -10), Quaternion.identity);
            
            MovePointer.Instance.SetNewLocalMiddlePoint(_currentPositionX);
        }
        
        public void MoveToNewRoom(Rooms nextRoom)
        {
            switch (nextRoom)
            {
                case Rooms.LivingRoom:
                    _currentPositionX = LivingRoomPosition;
                    break;
                
                case Rooms.Kitchen:
                    _currentPositionX = KitchenPosition;
                    break;
                
                case Rooms.Bedroom:
                    _currentPositionX = BedroomPosition;
                    break;
                
                case Rooms.Basement:
                    _currentPositionX = BasementPosition;
                    break;
            }
            
            MoveToCurrentPosition();
        }
    }
}