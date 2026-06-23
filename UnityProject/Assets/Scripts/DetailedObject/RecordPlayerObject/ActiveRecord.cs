using UnityEngine;

namespace FlorianMan.DetailedObject.RecordPlayerObject
{
    public class ActiveRecord : MonoBehaviour
    {
        public static ActiveRecord Instance {get; private set;}

        private void Awake()
        {
            Instance = this;
            
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Activate the Graphic if a Record is Placed
        /// </summary>
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