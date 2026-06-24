using System;
using UnityEngine;

namespace FlorianMan.UI
{
    public class TextBoxesUI : MonoBehaviour
    {
        public static TextBoxesUI Instance {get; private set;}
        
        private TextBoxUI[] _textBoxes;

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
        }
    }
}