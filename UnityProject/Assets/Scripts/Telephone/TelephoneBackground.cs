using UnityEngine;

namespace FlorianMan.Telephone
{
    public class TelephoneBackground : MonoBehaviour
    {
        private void OnMouseDown()
        {
            Telephone.Instance.Hide();
        }
    }
}