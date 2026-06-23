using UnityEngine;

namespace FlorianMan.DetailedObject.RecordPlayerObject
{
    public class RecordPlayerClose : MonoBehaviour
    {
        private void OnMouseDown()
        {
            RecordPlayer.Instance.Hide();
        }
    }
}