using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.Gameplay.Towers;

namespace Assets.Scripts.UI.Windows.TowerPropertyWindowInternal
{
    [Serializable] public class TowerInfo
    {
        [SerializeField] private Image _towerPreview;
        [SerializeField] private TextMeshProUGUI _damage;
        [SerializeField] private TextMeshProUGUI _health;
        [SerializeField] private TextMeshProUGUI _fireRate;
        [SerializeField] private TextMeshProUGUI _reward;

        public void UpdateValues(Sprite towerPreviewSprite, TowerAttributes attributes)
        {
            _towerPreview.sprite = towerPreviewSprite != null ? towerPreviewSprite : _towerPreview.sprite;
            _damage.text = $"{attributes.Damage.Value}";
            _health.text = $"{attributes.Health.Current}/{attributes.Health.Max}";
            _fireRate.text = $"{(1 / attributes.FireRate.Value).ToString("0.00")}/s";
            _reward.text = $"{attributes.RewardMultiplier.Value} x";
        }
    }
}