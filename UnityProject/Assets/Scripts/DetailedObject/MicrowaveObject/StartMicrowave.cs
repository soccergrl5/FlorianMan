using UnityEngine;

namespace FlorianMan.DetailedObject.MicrowaveObject
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