using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Gameplay;

namespace Assets.Scripts.UI
{
    public class BaseHealth : MonoBehaviour
    {
        [SerializeField] private Image _foreground;

        private void Start()
        {
            PlayerBase.Instance.OnHealthChanged += UpdateValue;
        }
        private void UpdateValue()
        {
            float healthPercent = PlayerBase.Instance.Health / (float)PlayerBase.MaxHealth;
            _foreground.rectTransform.localScale = new Vector3(healthPercent, 1, 1);
        }
    }
}