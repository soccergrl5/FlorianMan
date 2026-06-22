using UnityEngine;

namespace FlorianMan.Microwave
{
    public class MicrowaveClose : MonoBehaviour
    {
        private void OnMouseDown()
        {
            Microwave.Instance.Hide();
        }
    }
}