using System.Collections.Generic;
using FlorianMan.MainMenu;
using UnityEngine;

namespace FlorianMan.UI
{
    public class SubtitlesUI : MonoBehaviour
    {
        public static SubtitlesUI Instance {get; private set;}
        
        private SubtitleUI[] _textBoxes;

        private bool _showSubtitles;
        
        private List<Subtitles> _shownSubtitles = new ();

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _textBoxes = GetComponentsInChildren<SubtitleUI>(true);
            
            CheckSettings();
        }

        public void CheckSettings()
        {
            _showSubtitles = PlayerPrefs.GetInt(Settings.KeySubtitles, 0) == 1;
        }

        /// <summary>
        /// Show the given Subtitles
        /// </summary>
        /// <param name="subtitles">Subtitles to show</param>
        public void ShowSubtitles(Subtitles subtitles)
        {
            _shownSubtitles.Add(subtitles);
            
            if (!_showSubtitles) return;
            
            _textBoxes[(int)subtitles].Show();
        }
        
        public bool ShownTheSubtitle(Subtitles subtitles) => _shownSubtitles.Contains(subtitles);
    }
}