using UnityEngine;

namespace FlorianMan.DetectiveBook
{
    public class ClueUIElement : MonoBehaviour
    {
        [SerializeField] private GameObject clue;
        [SerializeField] private GameObject clueCover;

        public void RevealClue()
        {
            clue.SetActive(true);
            clueCover.SetActive(false);
        }
    }
}