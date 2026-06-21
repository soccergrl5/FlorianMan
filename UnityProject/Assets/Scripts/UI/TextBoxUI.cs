using UnityEngine;
using UnityEngine.UI;

namespace FlorianMan.UI
{
    public abstract class TextBoxUI : MonoBehaviour
    {
        [SerializeField] private GameObject[] textboxes;
        [SerializeField] private Button backgroundButton;
        
        private int _currentTextbox;

        protected void ActivateButton()
        {
            backgroundButton.onClick.AddListener(NextTextbox);
        }

        protected void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            
            textboxes[0].gameObject.SetActive(true);
        }

        private void NextTextbox()
        {
            textboxes[_currentTextbox].SetActive(false);
            _currentTextbox++;

            if (_currentTextbox == textboxes.Length)
            {
                Hide();
                return;
            }
            
            textboxes[_currentTextbox].SetActive(true);
        }
    }
}