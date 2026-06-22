using UnityEngine;

namespace FlorianMan.Fridge
{
    public class FridgeClose : MonoBehaviour
    {
        private void OnMouseDown()
        {
            Fridge.Instance.Hide();
        }
    }
}