using UnityEngine;
using TMPro;
using Assets.Scripts.Gameplay;

namespace Assets.Scripts.UI
{
    public class CurrentDayLabel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textField;

        private void Start()
        {
            TimeOfDay.Instance.OnStateChanged += UpdateDay;
            UpdateDay();
        }
        private void OnDisable()
        {
            TimeOfDay.Instance.OnStateChanged -= UpdateDay;
        }

        private void UpdateDay()
        {
            _textField.text = $"Day: {TimeOfDay.Instance.CurrentDay}";
        }
    }
}