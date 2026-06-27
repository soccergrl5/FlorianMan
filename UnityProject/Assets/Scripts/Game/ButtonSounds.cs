using UnityEngine;

namespace FlorianMan.Game
{
    public class ButtonSounds : MonoBehaviour
    {
        public static ButtonSounds Instance {get; private set;}
        
        private AudioSource _audioSource;

        private void Awake()
        {
            Instance = this;
            
            _audioSource = GetComponent<AudioSource>();
        }

        public void Play()
        {
            _audioSource.Play();
        }
    }
}