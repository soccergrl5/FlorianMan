using System;
using System.Collections.Generic;
using FlorianMan.DetectiveBook;
using FlorianMan.Inventory;
using UnityEngine;

namespace FlorianMan.UI
{
    public class TextBoxesUI : MonoBehaviour
    {
        public static TextBoxesUI Instance {get; private set;}
        
        private TextBoxUI[] _textBoxes;

        private HashSet<TextBoxes> _revealedBoxes = new ();
        
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _textBoxes = GetComponentsInChildren<TextBoxUI>(true);
        }

        public void ActivateTextBox(TextBoxes type)
        {
            if (type == TextBoxes.Empty) return;
            
            _textBoxes[(int)type].Show();
            
            ClueManager.Instance.TextboxTriggersClue(type);
            InventoryManager.Instance.TextboxTriggersItem(type);
            
            _revealedBoxes.Add(type);
        }
        
        public bool CheckIfTextWasShown(TextBoxes type) => _revealedBoxes.Contains(type);
    }
}