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
        /// <param name="clue">Clue to add to detective book</param>
        private void AddClue(Clues clue)
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

        /// <summary>
        /// Check if the Displayed Textbox also activates a clue in the detective book
        /// </summary>
        /// <param name="textbox">Type of the shown textbox</param>
        public void TextboxTriggersClue(TextBoxes textbox)
        {
            switch (textbox)
            {
                case TextBoxes.RavioliCanMorning:
                case TextBoxes.RavioliCanMurderDay:
                    AddClue(Clues.RavioliCan);
                    break;
                
                case TextBoxes.Bananas5:
                    AddClue(Clues.FiveBananasMorning);
                    break;
                
                case TextBoxes.Bananas4:
                    AddClue(Clues.FourBananasAfter);
                    break;
                
                case TextBoxes.BananaPeelBehindChair:
                    AddClue(Clues.BananaPeelBehindChair);
                    break;
                
                case TextBoxes.BananaPeelNextToCorpse:
                    AddClue(Clues.BananaPeelNextToCorpse);
                    break;
                
                case TextBoxes.InvitationLetter:
                    AddClue(Clues.PartyInvitation);
                    break;
                
                case TextBoxes.CakeRecipe:
                    AddClue(Clues.CakeRecipe);
                    break;
                
                case TextBoxes.FridgeFreezeButter:
                    AddClue(Clues.ButterFreezeInFridge);
                    break;
                
                case TextBoxes.PieceOfButterReachable:
                    AddClue(Clues.ButterNextToCircularSaw);
                    break;
                
                case TextBoxes.Finger:
                    AddClue(Clues.ChopedOfFinger);
                    break;
                
                case TextBoxes.BodyOutline:
                    AddClue(Clues.MissingFingerOnCorpse);
                    break;
                
                case TextBoxes.CeilingFanSwitchOnNormal:
                    AddClue(Clues.CeilingFanSwitchOnNormal);
                    break;
                
                case TextBoxes.CeilingFanWorking:
                    AddClue(Clues.CeilingFanWorking);
                    break;
                
                case TextBoxes.CeilingFanSwitchOnUltra:
                    AddClue(Clues.CeilingFanSwitchOnUltra);
                    break;
                
                case TextBoxes.CeilingFanBroken:
                    AddClue(Clues.CeilingFanBroken);
                    break;
                
                case TextBoxes.ShurikensHangingOnCeiling:
                    AddClue(Clues.ThrowingStarsHangingOnCeiling);
                    break;
                
                case TextBoxes.ShurikensInFloor:
                    AddClue(Clues.ThrowingStarsInCorps);
                    break;
                
                case TextBoxes.NoteInBedroom:
                    AddClue(Clues.EmergencyNoteInBedRoom);
                    break;
                
                case TextBoxes.RecordPlayerEvening:
                    AddClue(Clues.RecordPlayerPlaying);
                    break;
                
                case TextBoxes.NoteUnderneathShelf:
                    AddClue(Clues.EmergencyNoteUnderShelf);
                    break;
            }
        }
    }
}