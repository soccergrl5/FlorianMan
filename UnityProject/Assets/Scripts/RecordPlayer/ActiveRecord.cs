using UnityEngine;

namespace FlorianMan.RecordPlayer
{
    public class ActiveRecord : MonoBehaviour
    {
        public static ActiveRecord Instance {get; private set;}

        private void Awake()
        {
            Instance = this;
            
            gameObject.SetActive(false);
        }

        public void PlaceRecord()
        {
            gameObject.SetActive(true);
        }

        private void OnMouseDown()
        {
            RecordPlayer.Instance.ReleaseRecord();
            gameObject.SetActive(false);
        }
    }
}