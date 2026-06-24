using UnityEngine;

namespace FlorianMan.UI
{
    public class SubtitlesUI : MonoBehaviour
    {
        public static SubtitlesUI Instance {get; private set;}
        
        private SubtitleUI[] _textBoxes;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _textBoxes = GetComponentsInChildren<SubtitleUI>(true);
        }

        /// <summary>
        /// Show the given Subtitles
        /// </summary>
        /// <param name="subtitles">Subtitles to show</param>
        public void ShowSubtitles(Subtitles subtitles)
        {
            _textBoxes[(int)subtitles].Show();
        }
    }
}