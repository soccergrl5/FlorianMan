using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FlorianMan.Game
{
    public class RevealStory : MonoBehaviour
    {
        [SerializeField] private Button end;

        private void Awake()
        {
            end.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("EndScene");
            });
        }
    }
}