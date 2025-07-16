using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private Button restartButton;

        private void Awake()
        {
            
            restartButton.onClick.AddListener(OnRestartButtonClicked);
        }

        private void OnDestroy()
        {
            restartButton.onClick.RemoveListener(OnRestartButtonClicked);
        }

        private void OnRestartButtonClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
