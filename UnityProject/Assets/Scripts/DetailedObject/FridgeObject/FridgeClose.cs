using UnityEngine;

namespace FlorianMan.DetailedObject.FridgeObject
{
    public class FridgeClose : MonoBehaviour
    {
        private void OnMouseDown()
        {
            Fridge.Instance.Hide();
        }
    }
}