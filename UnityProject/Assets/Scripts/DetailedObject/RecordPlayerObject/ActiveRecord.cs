using UnityEngine;

namespace FlorianMan.DetailedObject.RecordPlayerObject
{
    public class ActiveRecord : MonoBehaviour
    {
        [SerializeField] private Sprite[] sprites;
        
        public static ActiveRecord Instance {get; private set;}

        private void Awake()
        {
            Instance = this;
            
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Activate the Graphic if a Record is Placed
        /// <param name="record">Number of the Record that is placed (to select the right sprite)</param>
        /// </summary>
        public void PlaceRecord(int record)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[record - 1];
            
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Remove the Graphic if there is no Record Placed
        /// </summary>
        public void RemoveRecord()
        {
            gameObject.SetActive(false);
        }

        private void OnMouseDown()
        {
            RecordPlayer.Instance.ReleaseRecord();
            gameObject.SetActive(false);
        }
    }
}