using System.Collections.Generic;
using FlorianMan.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlorianMan.DetectiveBook
{
    public class ClueManager : MonoBehaviour
    {
        public static ClueManager Instance {get; private set;}
        
        private List<Clues> _foundClues = new ();

        private const int TotalCluesAmount = 20;
        
        private void Awake()
        {
            Instance = this;
        }

        /// <summary>
        /// Add a Clue to the Detective Book
        /// </summary>
        /// <param name="clue"></param>
        public void AddClue(Clues clue)
        {
            if (_foundClues.Contains(clue)) return;
            
            _foundClues.Add(clue);
            
            DetectiveBookUI.Instance.RevealClue(clue);
            
            CheckForAllClues();
        }

        /// <summary>
        /// Check if all Clues are found
        /// </summary>
        private void CheckForAllClues()
        {
            if (_foundClues.Count == TotalCluesAmount)
            {
                SceneManager.LoadScene("EndScene");
            }
        }
        
        /// <summary>
        /// Check if a Clue is already found
        /// </summary>
        /// <param name="clue">The Clue to Check</param>
        /// <returns>True if the Clue was found, false otherwise</returns>
        public bool ContainsClue(Clues clue) => _foundClues.Contains(clue);
    }
}