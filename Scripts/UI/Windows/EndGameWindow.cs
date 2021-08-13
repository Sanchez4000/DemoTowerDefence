using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Assets.Scripts.Gameplay;

namespace Assets.Scripts.UI.Windows
{
    public class EndGameWindow : Window
    {
        [SerializeField] private TextMeshProUGUI _dayField;
        [SerializeField] private TextMeshProUGUI _scoreField;

        private void OnEnable()
        {
            Time.timeScale = 0;
            _dayField.text = $"Day\n{TimeOfDay.Instance.CurrentDay}";
            _scoreField.text = $"Score\n{PlayerData.Instance.Points}";
        }
        private void OnDisable()
        {
            Time.timeScale = 1;
        }

        public void RestartLevel()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}