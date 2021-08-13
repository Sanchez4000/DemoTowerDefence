using UnityEngine;
using TMPro;
using Assets.Scripts.Gameplay.Towers;
using Assets.Scripts.UI.Windows.TowerPropertyWindowInternal;
using Assets.Scripts.Gameplay;

namespace Assets.Scripts.UI.Windows
{
    public class TowerPropertyWindow : Window
    {
        [SerializeField] private TowerInfo _towerInfo;
        [SerializeField] private AttributeUpgrade _attributeUpgrade;
        [SerializeField] private TextMeshProUGUI _repairCost;
        [SerializeField] private TextMeshProUGUI _destroyCashback;

        private Tower _inspectedTower = null;

        private void OnEnable()
        {
            if (_inspectedTower == null)
                throw new System.Exception($"Null Reference \"Tower\" in {this}");

            UpdateValues();
        }
        private void OnDisable()
        {
            _inspectedTower = null;
        }
        private void FixedUpdate()
        {
            UpdateValues();
        }

        public void SetInspectedTower(Tower inspected)
        {
            _inspectedTower = inspected;
        }
        public void UpgradeDamage()
        {
            var damage = _inspectedTower.Attributes.Damage;

            if (PlayerData.Instance.TryGetMoney(damage.UpgradeCost)) 
            {
                if (damage.Level < damage.MaxLevel)
                {
                    damage.Upgrade();
                }
            }
        }
        public void UpgradeHealth()
        {
            var health = _inspectedTower.Attributes.Health;
            health.Upgrade();
        }
        public void UpgradeFireRate()
        {
            var fireRate = _inspectedTower.Attributes.FireRate;
            fireRate.Upgrade();
        }
        public void UpgradeReward()
        {
            var reward = _inspectedTower.Attributes.RewardMultiplier;
            reward.Upgrade();
        }
        public void RepairTower()
        {
            var towerHealth = _inspectedTower.Attributes.Health;
            int repairCost = (towerHealth.Max - towerHealth.Current) * towerHealth.Level;

            if (PlayerData.Instance.TryGetMoney(repairCost))
            {
                int deltaHealth = towerHealth.Max - towerHealth.Current;
                towerHealth.Restore(deltaHealth);
            }
        }
        public void DestroyTower()
        {
            PlayerData.Instance.AddMoney(_inspectedTower.Attributes.BaseCost);
            _inspectedTower.Destroy();
            _inspectedTower = null;
        }
        public void UpdateValues()
        {
            _towerInfo.UpdateValues(_inspectedTower.GetComponent<TowerPreviewData>().Image, _inspectedTower.Attributes);
            _attributeUpgrade.UpdateValues(_inspectedTower.Attributes);
            var towerHealth = _inspectedTower.Attributes.Health;
            int repairCost = (towerHealth.Max - towerHealth.Current) * (towerHealth.Level + 1);
            _repairCost.text = $"{repairCost}$";
            _destroyCashback.text = $"+ {_inspectedTower.Attributes.BaseCost}$";
        }
    }
}