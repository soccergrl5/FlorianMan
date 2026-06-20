using UnityEngine;

namespace FlorianMan
{
    public class CameraMovement : MonoBehaviour
    {
        public static CameraMovement Instance {get; private set;}

        private void Awake()
        {
            Instance = this;
        }
        
        public void MoveToLivingRoom()
        {
            transform.SetPositionAndRotation(new Vector3(0, 0, -10), Quaternion.identity);
        }
        
        public void MoveToKitchen()
        {
            transform.SetPositionAndRotation(new Vector3(25, 0, -10), Quaternion.identity);
        }

        public void MoveToBedroom()
        {
            transform.SetPositionAndRotation(new Vector3(50, 0, -10), Quaternion.identity);
        }

        public void MoveToBasement()
        {
            transform.SetPositionAndRotation(new Vector3(75, 0, -10), Quaternion.identity);
        }
    }
}