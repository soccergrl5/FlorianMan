using UnityEngine;
using UnityEngine.UI;

namespace FlorianMan.UI
{
    public class OpenClockUI : MonoBehaviour
    {
        public static OpenClockUI Instance {get; private set;}

        [SerializeField] private Button openButton;
        [SerializeField] private Button turnButton;

        private bool _clockVisible;
        
        private void Awake()
        {
            Instance = this;
            
            openButton.onClick.AddListener(() =>
            {
                _clockVisible = !_clockVisible;

                if (_clockVisible)
                {
                    Watch.Watch.Instance.Show();
                    ShowTurnButton();
                }
                else
                {
                    Watch.Watch.Instance.Hide();
                    HideTurnButton();
                }
            });

            turnButton.onClick.AddListener(() =>
            {
                Watch.Watch.Instance.TurnClock();
            });
            
            HideTurnButton();
        }

        private void HideTurnButton()
        {
            turnButton.gameObject.SetActive(false);
        }

        private void ShowTurnButton()
        {
            turnButton.gameObject.SetActive(true);
        }
    }
}