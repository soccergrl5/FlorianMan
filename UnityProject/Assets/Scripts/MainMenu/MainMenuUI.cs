using FlorianMan.Game;
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
                ButtonSounds.Instance.Play();
                
                SceneManager.LoadScene("LocalNews");
            });
            
            settingsButton.onClick.AddListener(() =>
            {
                Settings.Instance.Show();
                
                ButtonSounds.Instance.Play();
            });
            
            exitButton.onClick.AddListener(() =>
            {
                ButtonSounds.Instance.Play();
                
                Application.Quit();
            });
        }
    }
}