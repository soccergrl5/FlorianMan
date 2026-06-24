using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FlorianMan.MainMenu
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button settingsButton;

        private void Awake()
        {
            playButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("soccergrl");
            });
            
            settingsButton.onClick.AddListener(() =>
            {
                Settings.Instance.Show();
            });
        }
    }
}