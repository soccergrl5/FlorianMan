using UnityEngine;

namespace FlorianMan.Watch
{
    public class WatchCogwheel : MonoBehaviour
    {
        [SerializeField] private GameObject cogwheel;

        public void Placed()
        {
            cogwheel.SetActive(true);
        }
    }
}