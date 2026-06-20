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
                CameraMovement.Instance.MoveToLivingRoom();
            });
            
            buttons[1].onClick.AddListener(() =>
            {
                CameraMovement.Instance.MoveToKitchen();
            });
            
            buttons[2].onClick.AddListener(() =>
            {
                CameraMovement.Instance.MoveToBedroom();
            });
            
            buttons[3].onClick.AddListener(() =>
            {
                CameraMovement.Instance.MoveToBasement();
            });
        }
    }
}
