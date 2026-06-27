using FlorianMan.MainMenu;
using FlorianMan.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlorianMan.Game
{
    public class RevealStory : MonoBehaviour
    {
        [SerializeField] private SubtitleUI subtitle;
        [SerializeField] private AudioClip clip;
        
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponentInParent<AudioSource>();
        }

        public void RevealTruth()
        {
            if (PlayerPrefs.GetInt(Settings.KeySubtitles, 0) == 1)
            {
                subtitle.Show();
            }
            
            _audioSource.clip = clip;
            _audioSource.Play();
            
            Invoke(nameof(Credits), _audioSource.clip.length);
        }

        private void Credits()
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}