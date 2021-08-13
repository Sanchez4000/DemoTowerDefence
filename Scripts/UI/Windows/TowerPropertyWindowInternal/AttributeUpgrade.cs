using System;
using UnityEngine;
using Assets.Scripts.Gameplay.Towers;

namespace Assets.Scripts.UI.Windows.TowerPropertyWindowInternal
{
    [Serializable] public class AttributeUpgrade
    {
        [SerializeField] private AttributeUpgradeField _damage;
        [SerializeField] private AttributeUpgradeField _health;
        [SerializeField] private AttributeUpgradeField _fireRate;
        [SerializeField] private AttributeUpgradeField _reward;

        public void UpdateValues(TowerAttributes attributes)
        {
            _damage.UpdateValues(attributes.Damage);
            _health.UpdateValues(attributes.Health);
            _fireRate.UpdateValues(attributes.FireRate);
            _reward.UpdateValues(attributes.RewardMultiplier);
        }
    }
}