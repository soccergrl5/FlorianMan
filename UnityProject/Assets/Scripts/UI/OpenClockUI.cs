using FlorianMan.Watch;
using UnityEngine;
using UnityEngine.UI;

namespace FlorianMan.UI
{
    public class OpenClockUI : MonoBehaviour
    {
        public static OpenClockUI Instance {get; private set;}

        [SerializeField] private Button button;

        private bool _clockVisible;
        
        private void Awake()
        {
            Instance = this;
            
            button.onClick.AddListener(() =>
            {
                _clockVisible = !_clockVisible;
                
                if (_clockVisible) Watch.Watch.Instance.Show();
                else Watch.Watch.Instance.Hide();
            });
        }
    }
}