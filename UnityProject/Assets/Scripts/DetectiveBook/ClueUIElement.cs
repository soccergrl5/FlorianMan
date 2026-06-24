using UnityEngine;

namespace FlorianMan.DetectiveBook
{
    public class ClueUIElement : MonoBehaviour
    {
        [SerializeField] private GameObject clue;

        public void RevealClue()
        {
            clue.SetActive(true);
        }
    }
}