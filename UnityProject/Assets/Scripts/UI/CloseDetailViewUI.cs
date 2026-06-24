using FlorianMan.DetailedObject;
using FlorianMan.DetailedObject.FridgeObject;
using FlorianMan.DetailedObject.MicrowaveObject;
using FlorianMan.DetailedObject.RecordPlayerObject;
using FlorianMan.DetailedObject.TelephoneObject;
using UnityEngine;
using UnityEngine.UI;

namespace FlorianMan.UI
{
    public class CloseDetailViewUI : MonoBehaviour
    {
        public static CloseDetailViewUI Instance {get; private set;}

        [SerializeField] private Button button;

        private DetailedObjects _currentObject;
        
        private void Awake()
        {
            Instance = this;
            
            button.onClick.AddListener(() =>
            {
                gameObject.SetActive(false);

                switch (_currentObject)
                {
                    case DetailedObjects.Telephone:
                        Telephone.Instance.Hide();
                        break;
                    
                    case DetailedObjects.Microwave:
                        Microwave.Instance.Hide();
                        break;
                    
                    case DetailedObjects.Fridge:
                        Fridge.Instance.Hide();
                        break;
                    
                    case DetailedObjects.RecordPlayer:
                        RecordPlayer.Instance.Hide();
                        break;
                }
            });
            
            gameObject.SetActive(false);
        }
        
        public void OpenCloseButton(DetailedObjects currentObject)
        {
            _currentObject = currentObject;
            
            gameObject.SetActive(true);
        }
        
        public void LockButton() => button.interactable = false;
        
        public void UnlockButton() => button.interactable = true;
    }
}