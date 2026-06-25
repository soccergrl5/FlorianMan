using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FlorianMan.Game
{
    public class LocalNews : MonoBehaviour
    {
        [SerializeField] private Button start;

        private void Awake()
        {
            start.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("CurrentMain");
            });
        }
    }
}