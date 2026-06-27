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
        }

        private void Start()
        {
            Hide();
        }

        private void Hide()
        {
            gameObject.SetActive(false);
            
            InputBlockage.Instance.UnblockInput();
        }

        public void Show()
        {
            gameObject.SetActive(true);
            
            _currentTextbox = 0;
            
            textboxes[0].gameObject.SetActive(true);
            
            InputBlockage.Instance.BlockInput();
            
            Invoke(nameof(ActivateButton), 0.1f);
        }

        private void NextTextbox()
        {
            textboxes[_currentTextbox].SetActive(false);
            _currentTextbox++;

            if (_currentTextbox == textboxes.Length)
            {
                Hide();
                
                backgroundButton.interactable = false;
                return;
            }
            
            textboxes[_currentTextbox].SetActive(true);
        }

        private void ActivateButton()
        {
            backgroundButton.interactable = true;
        }
    }
}