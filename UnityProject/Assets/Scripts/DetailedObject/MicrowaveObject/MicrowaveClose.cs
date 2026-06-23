using UnityEngine;

namespace FlorianMan.DetailedObject.MicrowaveObject
{
    public class MicrowaveClose : MonoBehaviour
    {
        private void OnMouseDown()
        {
            Microwave.Instance.Hide();
        }
    }
}