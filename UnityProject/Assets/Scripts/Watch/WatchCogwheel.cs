using UnityEngine;

namespace FlorianMan.Watch
{
    public class WatchCogwheel : MonoBehaviour
    {
        [SerializeField] private GameObject cogwheel;

        /// <summary>
        /// Activate the Graphic for the Placed Cogwheel
        /// </summary>
        public void Placed()
        {
            cogwheel.SetActive(true);
        }
    }
}