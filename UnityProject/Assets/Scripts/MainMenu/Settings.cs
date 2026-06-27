using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using Slider = UnityEngine.UI.Slider;

namespace FlorianMan.MainMenu
{
    public class Settings : MonoBehaviour
    {
        public const string KeyVolume    = "Volume";
        public const string KeySubtitles = "Subtitles";
        
        public static Settings Instance;
        
        [SerializeField] private Slider volumeSlider;
        [SerializeField] private Button subtitlesButton;

        [SerializeField] private Button close;

        [SerializeField] private Sprite subtitlesOn;
        [SerializeField] private Sprite subtitlesOff;

        private float _volume = 1;
        private bool _subtitles = true;
        
        private void Awake()
        {
            Instance = this;

            volumeSlider.onValueChanged.AddListener(VolumeChange);
            subtitlesButton.onClick.AddListener(SubtitlesChange);
            
            close.onClick.AddListener(Hide);
            
            Hide();
        }

        private void Start()
        {
            _volume    = PlayerPrefs.GetFloat(KeyVolume, 1);
            _subtitles = PlayerPrefs.GetInt(KeySubtitles, 0) == 1;

            if (PlayerPrefs.GetInt("STARTED") == 0)
            {
                _subtitles = true;
                PlayerPrefs.SetInt(KeySubtitles, 1);
                PlayerPrefs.SetInt("STARTED", 1);
            }
            
            volumeSlider.value                                      = _volume;
            subtitlesButton.gameObject.GetComponent<Image>().sprite = _subtitles ? subtitlesOn : subtitlesOff;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }

        private void VolumeChange(float value)
        {
            _volume = value;
            PlayerPrefs.SetFloat(KeyVolume, value);
        }

        private void SubtitlesChange()
        {
            _subtitles = !_subtitles;
            PlayerPrefs.SetInt(KeySubtitles, _subtitles ? 1 : 0);
            
            subtitlesButton.GetComponent<Image>().sprite = _subtitles ? subtitlesOn : subtitlesOff;
        }
    }
}