using UnityEngine;
using UnityEngine.UI;

namespace FlorianMan.UI
{
    public class TextBoxUI : MonoBehaviour
    {
        [SerializeField] private GameObject[] textboxes;
        [SerializeField] private Button backgroundButton;
        
        private int _currentTextbox;

        private void Awake()
        {
            backgroundButton.onClick.AddListener(NextTextbox);
            
            Hide();
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            
            textboxes[0].gameObject.SetActive(true);
            
            InputBlockage.Instance.BlockInput();
        }

        private void NextTextbox()
        {
            textboxes[_currentTextbox].SetActive(false);
            _currentTextbox++;

            if (_currentTextbox == textboxes.Length)
            {
                _currentTextbox = 0;
                Hide();
                InputBlockage.Instance.UnblockInput();
                return;
            }
            
            textboxes[_currentTextbox].SetActive(true);
        }
    }
}