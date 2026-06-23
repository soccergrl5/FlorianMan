using FlorianMan.UI;
using UnityEngine;

namespace FlorianMan.DetailedObject.MicrowaveObject
{
    public class Microwave : MonoBehaviour
    {
        public static Microwave Instance {get; private set;}

        [SerializeField] private GameObject inside;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Hide();
        }

        /// <summary>
        /// Hide the Microwave
        /// </summary>
        public void Hide()
        {
            gameObject.SetActive(false);
            
            RoomPlanUI.Instance.Show();
            DetectiveBookUI.Instance.Show();
            OpenClockUI.Instance.Show();
        }

        /// <summary>
        /// Show the Microwave
        /// </summary>
        public void Show()
        {
            gameObject.SetActive(true);
            
            RoomPlanUI.Instance.Hide();
            DetectiveBookUI.Instance.Hide();
            OpenClockUI.Instance.Hide();
        }

        /// <summary>
        /// Start the Microwave
        /// </summary>
        public void StartMicrowave()
        {
            MicrowaveDoor.Instance.LockDoor();
            
            Invoke(nameof(EndMicrowaving), 5f);
        }

        /// <summary>
        /// End the Microwaving Process
        /// </summary>
        private void EndMicrowaving()
        {
            MicrowaveDoor.Instance.UnlockDoor();
            
            if (MicrowaveButter.Instance.gameObject.activeSelf)
                MicrowaveButter.Instance.Microwaved();
        }

        /// <summary>
        /// Check if the Butter Item is at the right Position to be Placed inside the Microwave
        /// </summary>
        /// <param name="position">Position of the Butter Item</param>
        /// <returns>True if it can be Placed in the Microwave, False otherwise</returns>
        public bool ButterIsAtRightPosition(Vector3 position)
        {
            if (!gameObject.activeSelf) return false;
            if (!MicrowaveDoor.Instance.DoorIsOpen()) return false;

            Vector3 positionRecord = inside.transform.position;
            float scaleX = inside.transform.localScale.x / 2;
            float scaleY = inside.transform.localScale.y / 2;

            if (position.x < positionRecord.x + scaleX
                && position.x > positionRecord.x - scaleX
                && position.y < positionRecord.y + scaleY
                && position.y > positionRecord.y - scaleY)
            {
                MicrowaveButter.Instance.Show();
                
                return true;
            }
            
            return false;
        }
    }
}