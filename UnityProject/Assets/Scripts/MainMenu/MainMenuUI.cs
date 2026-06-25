using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FlorianMan.MainMenu
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button exitButton;

        private void Awake()
        {
            playButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("CurrentMain");
            });
            
            settingsButton.onClick.AddListener(() =>
            {
                Settings.Instance.Show();
            });
            
            exitButton.onClick.AddListener(() =>
            {
                Application.Quit();
            });
        }
    }
}