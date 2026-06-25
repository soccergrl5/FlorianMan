using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FlorianMan.Game
{
    public class Credits : MonoBehaviour
    {
        [SerializeField] private Button backToMainMenu;

        private void Awake()
        {
            backToMainMenu.onClick.AddListener((() =>
            {
                SceneManager.LoadScene("MainMenu");
            }));
        }
    }
}