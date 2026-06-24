using FlorianMan.MainMenu;
using UnityEngine;

namespace FlorianMan.Game
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance {get; private set;}

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            CheckSettings();
        }

        public void CheckSettings()
        {
            foreach (AudioSource audioSource in FindObjectsByType<AudioSource>(FindObjectsInactive.Include, FindObjectsSortMode.None))
            {
                audioSource.volume = PlayerPrefs.GetFloat(Settings.KeyVolume, 1);
            }
        }
    }
}