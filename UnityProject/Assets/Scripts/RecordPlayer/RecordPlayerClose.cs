using UnityEngine;

namespace FlorianMan.RecordPlayer
{
    public class RecordPlayerClose : MonoBehaviour
    {
        private void OnMouseDown()
        {
            RecordPlayer.Instance.Hide();
        }
    }
}