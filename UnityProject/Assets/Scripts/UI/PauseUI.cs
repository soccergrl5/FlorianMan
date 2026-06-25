using FlorianMan.Game;
using FlorianMan.MainMenu;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FlorianMan.UI
{
    public class PauseUI : MonoBehaviour
    {
        public static PauseUI Instance {get; private set;}
        
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private GameObject panel;

        [SerializeField] private Button settings;

        private bool _onPause;
        
        private void Awake()
        {
            Instance = this;
            
            pauseButton.onClick.AddListener(() =>
            {
                _onPause = !_onPause;
                
                panel.SetActive(_onPause);
                
                if (_onPause) InputBlockage.Instance.BlockInput();
                else
                {
                    InputBlockage.Instance.UnblockInput();
                    AudioManager.Instance.CheckSettings();
                    SubtitlesUI.Instance.CheckSettings();
                }
            });

            quitButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("MainMenu");
            });
            
            settings.onClick.AddListener(() =>
            {
                Settings.Instance.Show();
            });
            
            panel.SetActive(false);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}