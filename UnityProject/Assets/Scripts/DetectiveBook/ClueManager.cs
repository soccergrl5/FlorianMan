using System.Collections.Generic;
using FlorianMan.UI;
using UnityEngine;

namespace FlorianMan.DetectiveBook
{
    public class ClueManager : MonoBehaviour
    {
        public static ClueManager Instance {get; private set;}
        
        private List<Clues> _foundClues = new ();

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
            _foundClues.Add(clue);
            
            DetectiveBookUI.Instance.RevealClue(clue);
        }
    }
}