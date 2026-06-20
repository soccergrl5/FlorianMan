using FlorianMan.Game;
using UnityEngine;
using UnityEngine.UI;

namespace FlorianMan.UI
{
    public class RoomPlanUI : MonoBehaviour
    {
        public static RoomPlanUI Instance {get; private set;}
        
        [SerializeField] private Button[] buttons;

        private void Awake()
        {
            Instance = this;
            
            buttons[0].onClick.AddListener(() =>
            {
                RoomManager.Instance.ChangeToRoom(Rooms.LivingRoom);
            });
            
            buttons[1].onClick.AddListener(() =>
            {
                RoomManager.Instance.ChangeToRoom(Rooms.Kitchen);
            });
            
            buttons[2].onClick.AddListener(() =>
            {
                RoomManager.Instance.ChangeToRoom(Rooms.Bedroom);
            });
            
            buttons[3].onClick.AddListener(() =>
            {
                RoomManager.Instance.ChangeToRoom(Rooms.Basement);
            });
        }
    }
}
