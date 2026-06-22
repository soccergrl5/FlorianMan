using TMPro;
using UnityEngine;

namespace FlorianMan.DetectiveBook
{
    public class ClueUIElement : MonoBehaviour
    {
        [SerializeField] private TMP_Text clueText;

        /// <summary>
        /// Set the Text on the Clue in the Book
        /// </summary>
        /// <param name="text">The Text that is visible</param>
        public void SetClueText(string text)
        {
            clueText.text = text;
        }
    }
}