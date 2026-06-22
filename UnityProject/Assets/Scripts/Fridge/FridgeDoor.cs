using UnityEngine;

namespace FlorianMan.Fridge
{
    public class FridgeDoor : MonoBehaviour
    {
        private void OnMouseDown()
        {
            Fridge.Instance.DoorInteraction();
            
            gameObject.SetActive(false);
        }
    }
}