using System;
using FlorianMan.MainMenu;
using UnityEngine;

namespace FlorianMan.Game
{
    public class AudioManager : MonoBehaviour
    {
        private void Start()
        {
            foreach (AudioSource audioSource in FindObjectsByType<AudioSource>(FindObjectsInactive.Include, FindObjectsSortMode.None))
            {
                audioSource.volume = PlayerPrefs.GetFloat(Settings.KeyVolume, 1);
            }
        }
    }
}