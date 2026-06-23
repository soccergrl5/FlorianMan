using UnityEngine;

namespace FlorianMan.DetailedObject.FridgeObject
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