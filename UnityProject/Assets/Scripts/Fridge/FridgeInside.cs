using UnityEngine;

namespace FlorianMan.Fridge
{
    public class FridgeInside : MonoBehaviour
    {
        public static FridgeInside Instance;

        [SerializeField] private GameObject cold;
        [SerializeField] private GameObject warm;

        private void Awake()
        {
            Instance = this;
        }

        /// <summary>
        /// The Fridge should be Warm Inside
        /// </summary>
        public void WarmInside()
        {
            warm.SetActive(true);
            cold.SetActive(false);
            
            if (FrozenCogwheel.Instance != null) FrozenCogwheel.Instance.Unfreeze();
        }

        /// <summary>
        /// The Fridge should be Cold Inside
        /// </summary>
        public void ColdInside()
        {
            warm.SetActive(false);
            cold.SetActive(true);
            
            if (FrozenCogwheel.Instance != null) FrozenCogwheel.Instance.Freeze();
        }
    }
}