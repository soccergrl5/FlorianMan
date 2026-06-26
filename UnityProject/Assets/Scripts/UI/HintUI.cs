using System.Collections.Generic;
using FlorianMan.DetectiveBook;
using FlorianMan.Inventory;
using FlorianMan.Watch;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FlorianMan.UI
{
    public class HintUI : MonoBehaviour
    {
        public static HintUI Instance {get; private set;}

        [SerializeField] private Button button;
        [SerializeField] private TMP_Text text;
        [SerializeField] private GameObject textBox;

        [SerializeField] private Button background;

        private bool _usedFirstTime;
        private bool _activeHint;

        private List<bool> _showFirstHint = new ();
        
        private void Awake()
        {
            Instance = this;
            
            button.onClick.AddListener(() =>
            {
                if (!_activeHint) LookForHint();
            });
            
            background.onClick.AddListener(() =>
            {
                background.gameObject.SetActive(false);
                
                HideTextbox();
                text.text = "";
            });

            for (int i = 0; i <= 36; i++)
            {
                _showFirstHint.Add(true);
            }
        }

        private void Start()
        {
            HideTextbox();
        }

        private void LookForHint()
        {
            background.gameObject.SetActive(true);
            
            if (!_usedFirstTime)
            {
                text.text =
                    "In Case of Emergency you can get a Hint here. But the Clock is always a good start ;-)";
                ShowTextbox();
                _usedFirstTime = true;
                return;
            }
            
            switch (TimeManager.Instance.GetUnlockedTimes())
            {
                case 1:
                    //Find the Emergency Note
                    if (!TextBoxesUI.Instance.CheckIfTextWasShown(TextBoxes.NoteUnderneathShelf))
                    {
                        text.text = _showFirstHint[0] ? "Look around in the Living Room" : "There is a Note under the Shelf";
                        _showFirstHint[0] = false;
                    }
                    //Call 811
                    else if (!SubtitlesUI.Instance.ShownTheSubtitle(Subtitles.Call811))
                    {
                        text.text = _showFirstHint[1] ? "Try doing what the Note says" : "Call 811 on the Telephone";
                        _showFirstHint[1] = false;
                    }
                    //Find Toy
                    else if (!TextBoxesUI.Instance.CheckIfTextWasShown(TextBoxes.ToyOnShelfMorning))
                    {
                        text.text = _showFirstHint[2]
                            ? "Maybe there is a Toy with a Cogwheel here"
                            : "There is a Toy in the Shelf";
                        _showFirstHint[2] = false;
                    }
                    //Insert Cogwheel
                    else
                    {
                        text.text = _showFirstHint[3]
                            ? "Have a closer Look at the Clock"
                            : "Try inserting the Cogwheel into the Back of the Clock";
                        _showFirstHint[3] = false;
                    }
                    break;
                
                case 2:
                    //Turn the Clock
                    if (!TextBoxesUI.Instance.CheckIfTextWasShown(TextBoxes.RecordPlayerArrivalOtherRoom) &&
                        !TextBoxesUI.Instance.CheckIfTextWasShown(TextBoxes.RecordPlayerArrivalSameRoom))
                    {
                        text.text = _showFirstHint[4]
                            ? "I can find out more if i look in the Past"
                            : "Turn the Clock back";
                        _showFirstHint[4] = false;
                    }
                    //Find the Record Player
                    else if (!TextBoxesUI.Instance.CheckIfTextWasShown(TextBoxes.RecordPlayerEvening))
                    {
                        text.text = _showFirstHint[5]
                            ? "Look in all the Rooms for the Record Player"
                            : "There is a Record Player in the Bedroom";
                        _showFirstHint[5] = false;
                        
                    }
                    //Find the Cryss Angel Vinyl
                    else if (!TextBoxesUI.Instance.CheckIfTextWasShown(TextBoxes.CryssAngleVinyl))
                    {
                        text.text = _showFirstHint[6]
                            ? "Maybe he has another Vinyl somewhere"
                            : "There is another Vinyl in the Shelf in the Living Room";
                        _showFirstHint[6] = false;
                    }
                    //Play the Cryss Angel Vinyl
                    else if (!TextBoxesUI.Instance.CheckIfTextWasShown(TextBoxes.CryssAngleVinylIn))
                    {
                        text.text = _showFirstHint[7]
                            ? "I wonder whats on the Vinyl I found in the Living Room"
                            : "Put the \"Cryss Angel\" Vinyl in the Record Player";
                        _showFirstHint[7] = false;
                    }
                    //Play it Backwards
                    else if (!SubtitlesUI.Instance.ShownTheSubtitle(Subtitles.CryssAngelVinyl))
                    {
                        text.text = _showFirstHint[8]
                            ? "The Record Player hast different Play Options"
                            : "Play the Vinyl Backwards";
                        _showFirstHint[8] = false;
                    }
                    //Check the Fridge
                    else if (!TextBoxesUI.Instance.CheckIfTextWasShown(TextBoxes.FridgeFreeze))
                    {
                        text.text = _showFirstHint[9]
                            ? "It mentioned a Cogwheel in the Fridge. Maybe look there"
                            : "Open the Fridge. There is a Cogwheel in there";
                        _showFirstHint[9] = false;
                    }
                    //Turn the Fridge warm
                    else if (!TextBoxesUI.Instance.CheckIfTextWasShown(TextBoxes.FridgeRegulator))
                    {
                        text.text = _showFirstHint[10]
                            ? "Maybe there is an Option to Warm up the Fridge"
                            : "Try turning the Regulator on the Fridge";
                        _showFirstHint[10] = false;
                    }
                    //Go Forward in Time to unfreeze Fridge
                    else if (!InventoryManager.Instance.InventoryContains(InventoryItems.Cogwheel2))
                    {
                        text.text = _showFirstHint[11]
                            ? "The Fridge needs some Time to warm up"
                            : "Turn the Clock forward to 7 AM";
                        _showFirstHint[11] = false;
                    }
                    //Put in the second Cogwheel
                    else
                    {
                        text.text = _showFirstHint[12]
                            ? "The Clock has enough Space for more Cogwheels"
                            : "Try inserting the second Cogwheel into the Back of the Clock";
                        _showFirstHint[12] = false;
                    }
                    break;
                
                case 3:
                    //Turn back the Time
                    if (TimeManager.Instance.GetCurrentTime() != Times.Afternoon &&
                        !SubtitlesUI.Instance.ShownTheSubtitle(Subtitles.CallCircularSaw))
                    {
                        text.text = _showFirstHint[13]
                            ? "2 Cogwheels, maybe I can turn back even further"
                            : "Turn Back the Clock to 4 PM";
                        _showFirstHint[13] = false;
                    }
                    //Listen to the Phone Call
                    else if (!SubtitlesUI.Instance.ShownTheSubtitle(Subtitles.CallCircularSaw))
                    {
                        text.text = _showFirstHint[14]
                            ? "The Telephone is ringing. Who might be calling?"
                            : "Pick up the Telephone";
                        _showFirstHint[14] = false;
                    }
                    //Find the Butter in the Basement
                    else if (!TextBoxesUI.Instance.CheckIfTextWasShown(TextBoxes.PieceOfButterReachable))
                    {
                        text.text = _showFirstHint[15]
                            ? "Maybe I find something at the Circular Saw"
                            : "There is a Piece of Butter next to the Circular Saw in the Basement";
                        _showFirstHint[15] = false;
                    }
                    //Unfreeze the Butter
                    else if (InventoryManager.Instance.InventoryContains(InventoryItems.Butter))
                    {
                        text.text = _showFirstHint[16]
                            ? "I need something to melt that Butter. Maybe something in the Kitchen?"
                            : "Melt the Butter in the Microwave";
                        _showFirstHint[16] = false;
                    }
                    //Insert Cogwheel
                    else
                    {
                        text.text = _showFirstHint[17]
                            ? "Another Cogwheel for my Clock"
                            : "Try inserting the third Cogwheel into the Back of the Clock";
                        _showFirstHint[17] = false;
                    }
                    break;
                
                case 4:
                    //Find more Clues
                    if (_showFirstHint[18])
                    {
                        text.text = "Find more Clues to figure out how the Floorian Man was killed. You have your current Notes in the Detective Book";
                        _showFirstHint[18] = false;
                    }
                    // Not found a single other clue
                    else if (ClueManager.Instance.OnlyContainsStoryClues() && _showFirstHint[19])
                    {
                        text.text = "Seriously? You haven't tried clicking on anything else the whole Time?";
                        _showFirstHint[19] = false;
                    }
                    // Shurikens
                    else if (!ClueManager.Instance.ContainsClue(Clues.ThrowingStarsInCorps))
                    {
                        text.text = _showFirstHint[20]
                            ? "Maybe you want to figure out how he was killed?"
                            : "There are Shurikens next to his Body";
                        _showFirstHint[20] = false;
                    }
                    // Banana Peel Next to Body
                    else if (!ClueManager.Instance.ContainsClue(Clues.BananaPeelNextToCorpse))
                    {
                        text.text = _showFirstHint[21]
                            ? "If there was a Murderer here, he maybe left something behind?"
                            : "There is a Banana Peel next to the Dead Body";
                        _showFirstHint[21] = false;
                    }
                    // The Body Outline
                    else if (!ClueManager.Instance.ContainsClue(Clues.MissingFingerOnCorpse))
                    {
                        text.text = _showFirstHint[22]
                            ? "Maybe you can figure out more about the Dead Body even afterwards?"
                            : "The Body outline in the Morning looks interesting, don't you think?";
                        _showFirstHint[22] = false;
                    }
                    // Finger
                    else if (!ClueManager.Instance.ContainsClue(Clues.ChopedOfFinger))
                    {
                        text.text = _showFirstHint[23]
                            ? "The Body outline was missing a Finger. Where could that be? An accident with the Circular Saw?"
                            : "He choped of his finger trying to cut the Butter. Look in the Basement";
                        _showFirstHint[23] = false;
                    }
                    // Ravioli
                    else if (!ClueManager.Instance.ContainsClue(Clues.RavioliCan))
                    {
                        text.text = _showFirstHint[24]
                            ? "Why wouldn't he just use a Knife to cut the Butter?"
                            : "The Knife is stuck in a Ravioli Can in the Kitchen";
                        _showFirstHint[24] = false;
                    }
                    // Butter Freezing
                    else if (!ClueManager.Instance.ContainsClue(Clues.ButterFreezeInFridge))
                    {
                        text.text = _showFirstHint[25]
                            ? "So he used the Circular Saw to cut the Butter. Was the Butter that hard?"
                            : "Maybe the Butter was in the Freezing Fridge in the Morning";
                        _showFirstHint[25] = false;
                    }
                    // Cake Recipe
                    else if (!ClueManager.Instance.ContainsClue(Clues.CakeRecipe))
                    {
                        text.text = _showFirstHint[26]
                            ? "Why did he even need to cut the Butter? Was he baking something?"
                            : "Maybe he has a Recipe in the Kitchen";
                        _showFirstHint[26] = false;
                    }
                    // Party Invitation
                    else if (!ClueManager.Instance.ContainsClue(Clues.PartyInvitation))
                    {
                        text.text = _showFirstHint[27]
                            ? "He was trying to bake a Cake. But for what? A Party?"
                            : "Maybe an Invitation in his Bedroom?";
                        _showFirstHint[27] = false;
                    }
                    // Shurikens on Ceiling
                    else if (!ClueManager.Instance.ContainsClue(Clues.ThrowingStarsHangingOnCeiling))
                    {
                        text.text = _showFirstHint[28]
                            ? "So you know he wasn't the smartest Man with that Butter Thing. Maybe he also had Shurikens at Home?"
                            : "Are there Shurikens ... hanging at the Ceiling Fan?!";
                        _showFirstHint[28] = false;
                    }
                    // Ceiling Fan Working
                    else if (!ClueManager.Instance.ContainsClue(Clues.CeilingFanWorking))
                    {
                        text.text = _showFirstHint[29] ? "The Shurikens were hanging where?" : "A working Ceiling Fan";
                        _showFirstHint[29] = false;
                    }
                    // Ceiling Fan Broken
                    else if (!ClueManager.Instance.ContainsClue(Clues.CeilingFanBroken))
                    {
                        text.text = _showFirstHint[30]
                            ? "If the Shurikens were hanging on the Fan .. then why where they in his Body later?"
                            : "The Ceiling Fan is broken later";
                        _showFirstHint[30] = false;
                    }
                    // Ceiling Fan Switch On Ultra
                    else if (!ClueManager.Instance.ContainsClue(Clues.CeilingFanSwitchOnUltra))
                    {
                        text.text = _showFirstHint[31]
                            ? "How did the Ceiling Fan Break? Does it have a Remote Control?"
                            : "A Remote Control in The Living Room, that is set to \"Ultra\"";
                        _showFirstHint[31] = false;
                    }
                    // Ceiling Fan Switch On Normal
                    else if (!ClueManager.Instance.ContainsClue(Clues.CeilingFanSwitchOnNormal))
                    {
                        text.text = _showFirstHint[32]
                            ? "Was the Remote Switch always set to ultra?"
                            : "Before his Death it was on Normal";
                        _showFirstHint[32] = false;
                    }
                    // 4 Bananas
                    else if (!ClueManager.Instance.ContainsClue(Clues.FourBananasAfter))
                    {
                        text.text = _showFirstHint[33]
                            ? "So if the Shurikens were his, maybe the Banana Peel also"
                            : "Bananas in the Kitchen";
                        _showFirstHint[33] = false;
                    }
                    // 5 Bananas
                    else if (!ClueManager.Instance.ContainsClue(Clues.FiveBananasMorning))
                    {
                        text.text = _showFirstHint[34]
                            ? "4 Bananas? And a Banana Peel that was maybe his? Did he eat one?"
                            : "There were more Bananas at Noon";
                        _showFirstHint[34] = false;
                    }
                    // Banana Peel Behind Chair
                    else if (!ClueManager.Instance.ContainsClue(Clues.BananaPeelBehindChair))
                    {
                        text.text = _showFirstHint[35]
                            ? "5 Bananas at Noon and a Banana Peel next to his Body? So where was the Banana Peel at Afternoon?"
                            : "Have a look behind the Chair";
                        _showFirstHint[35] = false;
                    }
                    // Emergency Note Bedroom
                    else if (!ClueManager.Instance.ContainsClue(Clues.EmergencyNoteInBedRoom))
                    {
                        text.text = _showFirstHint[36]
                            ? "Leaves the Question, where was the Note coming from, that told him to Play Music?"
                            : "The Note was hanging in the Bedroom earlier";
                        _showFirstHint[36] = false;
                    }
                    else
                    {
                        text.text = "Look through your Detective Book";
                    }
                    
                    break;
            }
            
            ShowTextbox();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            button.interactable = false;
        }

        public void Enable()
        {
            button.interactable = true;
        }

        private void HideTextbox()
        {
            textBox.SetActive(false);

            InputBlockage.Instance.UnblockInput();
            _activeHint = false;
        }

        private void ShowTextbox()
        {
            textBox.SetActive(true);
            
            InputBlockage.Instance.BlockInput();
            _activeHint = true;
        }
    }
}