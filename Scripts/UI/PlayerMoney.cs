using UnityEngine;
using TMPro;
using Assets.Scripts.Gameplay;

namespace Assets.Scripts.UI
{
    public class PlayerMoney : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textField;

        private void Start()
        {
            PlayerData.Instance.OnChangeMoney += UpdateMoney;
            UpdateMoney();
        }
        private void OnDestroy()
        {
            PlayerData.Instance.OnChangeMoney -= UpdateMoney;
        }

        private void UpdateMoney()
        {
            _textField.text = $"${PlayerData.Instance.Money}";
        }
    }
}