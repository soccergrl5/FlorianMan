using UnityEngine;

namespace FlorianMan.UI
{
    public class SubtitleUI : MonoBehaviour
    {
        [SerializeField] private GameObject[] textLines;
        [SerializeField] private float[] textLengths;
        
        private int _currentText;

        private void Awake()
        {
            Hide();
        }

        /// <summary>
        /// Hide the Subtitles
        /// </summary>
        private void Hide()
        {
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Show the Subtitles
        /// </summary>
        public void Show()
        {
            gameObject.SetActive(true);
            
            textLines[0].gameObject.SetActive(true);
            Invoke(nameof(NextTextbox), textLengths[_currentText]);
        }

        /// <summary>
        /// Show the next Subtitle
        /// </summary>
        private void NextTextbox()
        {
            textLines[_currentText].SetActive(false);
            _currentText++;

            if (_currentText == textLines.Length)
            {
                _currentText = 0;
                Hide();
                return;
            }
            
            textLines[_currentText].SetActive(true);
            Invoke(nameof(NextTextbox), textLengths[_currentText]);
        }
    }
}