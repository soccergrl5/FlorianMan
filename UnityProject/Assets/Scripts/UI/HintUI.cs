using FlorianMan.Watch;
using UnityEngine;
using UnityEngine.UI;

namespace FlorianMan.UI
{
    public class HintUI : MonoBehaviour
    {
        public static HintUI Instance {get; private set;}

        [SerializeField] private Button button;
        
        private void Awake()
        {
            Instance = this;
            
            button.onClick.AddListener(() =>
            {
                LookForHint();
            });
        }

        private void LookForHint()
        {
            switch (TimeManager.Instance.GetUnlockedTimes())
            {
                case 1:
                    
                    break;
                
                case 2:
                    break;
                
                case 3:
                    break;
                
                case 4:
                    break;
            }
        }
    }
}