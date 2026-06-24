using FlorianMan.Watch;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FlorianMan.UI
{
    public class HintUI : MonoBehaviour
    {
        public static HintUI Instance {get; private set;}

        [SerializeField] private Button button;
        [SerializeField] private TMP_Text text;
        [SerializeField] private GameObject textBox;

        [SerializeField] private Button background;

        private bool _usedFirstTime;
        
        private void Awake()
        {
            Instance = this;
            
            button.onClick.AddListener(() =>
            {
                LookForHint();
            });
            
            background.onClick.AddListener(() =>
            {
                background.gameObject.SetActive(false);
                
                HideTextbox();
                text.text = "";
            });
            
            HideTextbox();
        }

        private void LookForHint()
        {
            background.gameObject.SetActive(true);
            
            if (!_usedFirstTime)
            {
                text.text =
                    "Here you can get a Hint if you don't know what to do.\n Please use in Case of Emergency Only";
                ShowTextbox();
                _usedFirstTime = true;
            }
            
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

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        private void HideTextbox()
        {
            textBox.SetActive(false);
        }

        private void ShowTextbox()
        {
            textBox.SetActive(true);
        }
    }
}