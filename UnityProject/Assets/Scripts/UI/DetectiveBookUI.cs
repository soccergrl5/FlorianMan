using FlorianMan.DetectiveBook;
using FlorianMan.Game;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FlorianMan.UI
{
    public class DetectiveBookUI : MonoBehaviour
    {
        public static DetectiveBookUI Instance {get; private set;}

        [SerializeField] private Button button;
        [SerializeField] private GameObject[] pages;
        [SerializeField] private GameObject book;

        [SerializeField] private Button[] turnButtons;
        [SerializeField] private Button revealStoryButton;

        private int[] _amountCluesOnPage;
        private int _visualPage;
        
        private void Awake()
        {
            Instance = this;
            
            button.onClick.AddListener(() =>
            {
                ButtonSounds.Instance.Play();

                if (book.activeSelf)
                {
                    HideBook();
                    
                    HintUI.Instance.Enable();
                    OpenClockUI.Instance.Enable();
                }
                else
                {
                    ShowBook();
                    
                    HintUI.Instance.Disable();
                    OpenClockUI.Instance.Disable();
                    
                    if (!TextBoxesUI.Instance.CheckIfTextWasShown(TextBoxes.DetectiveBook))
                        TextBoxesUI.Instance.ActivateTextBox(TextBoxes.DetectiveBook);
                }
            });
            revealStoryButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("RevealStory");
            });

            turnButtons[0].onClick.AddListener(PreviousPage);
            turnButtons[1].onClick.AddListener(NextPage);
            
            revealStoryButton.gameObject.SetActive(false);
        }

        private void Start()
        {
            HideBook();
            
            _amountCluesOnPage = new int[pages.Length];

            for (int i = 0; i < _amountCluesOnPage.Length; i++)
            {
                _amountCluesOnPage[i] = pages[i].GetComponentsInChildren<ClueUIElement>().Length;
            }
            
            _visualPage = 0;
        }

        /// <summary>
        /// Hide the Detective Book
        /// </summary>
        private void HideBook()
        {
            book.SetActive(false);
            
            InputBlockage.Instance.UnblockInput();
        }

        /// <summary>
        /// Show the Detective Book
        /// </summary>
        private void ShowBook()
        {
            book.SetActive(true);
            
            InputBlockage.Instance.BlockInput();
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Disable the Detective Book Button
        /// </summary>
        public void Disable()
        {
            button.interactable = false;
        }

        /// <summary>
        /// Enable the Detective Book Button
        /// </summary>
        public void Enable()
        {
            button.interactable = true;
        }

        /// <summary>
        /// Show the next Page of the Book
        /// </summary>
        private void NextPage()
        {
            pages[_visualPage].SetActive(false);
            _visualPage++;
            pages[_visualPage].SetActive(true);
            
            //Check if it's the last Page
            if (_visualPage == _amountCluesOnPage.Length - 1)
                turnButtons[1].interactable = false;
            
            turnButtons[0].interactable = true;
        }

        /// <summary>
        /// Show the previous Page of the Book
        /// </summary>
        private void PreviousPage()
        {
            pages[_visualPage].SetActive(false);
            _visualPage--;
            pages[_visualPage].SetActive(true);
            
            //Check if it's the first Page
            if (_visualPage == 0)
                turnButtons[0].interactable = false;
            
            turnButtons[1].interactable = true;
        }

        /// <summary>
        /// Reveal a Clue in the Book
        /// </summary>
        /// <param name="clue">Clue to reveal</param>
        public void RevealClue(Clues clue)
        {
            int clueNumber = (int)clue;

            for (int i = 0; i < _amountCluesOnPage.Length; i++)
            {
                //Check which Page the Clue is on
                if (clueNumber >= _amountCluesOnPage[i])
                {
                    clueNumber -= _amountCluesOnPage[i];
                    continue;
                }

                ClueUIElement clueText = pages[i].GetComponentsInChildren<ClueUIElement>()[clueNumber];
                clueText.RevealClue();
                break;
            }
        }
        
        public void ActivateRevealStoryButton() => revealStoryButton.gameObject.SetActive(true);
    }
}