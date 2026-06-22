using UnityEngine;

namespace FlorianMan.Microwave
{
    public class StartMicrowave : MonoBehaviour
    {
        private void OnMouseDown()
        {
            if(MicrowaveDoor.Instance.DoorIsOpen()) return;
            
            Microwave.Instance.StartMicrowave();
        }
    }
}