using UnityEngine;

namespace FlorianMan
{
    public class InputBlockage : MonoBehaviour
    {
        public static InputBlockage Instance;

        private void Awake()
        {
            Instance = this;
            
            UnblockInput();
        }

        public void BlockInput()
        {
            gameObject.SetActive(true);
        }

        public void UnblockInput()
        {
            gameObject.SetActive(false);
        }
    }
}