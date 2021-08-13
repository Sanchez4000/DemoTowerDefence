using System;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Towers.Attributes
{
    [Serializable] public abstract class Attribute
    {
        [SerializeField] protected int _level;
        [SerializeField] protected int _maxLevel;
        [SerializeField] protected int _upgradeCostPerLevel;

        public int Level => _level;
        public int MaxLevel => _maxLevel;
        public int UpgradeCost => _upgradeCostPerLevel * (_level + 1);

        protected abstract void UpgradeRealize();

        public bool Upgrade()
        {
            if (_level < _maxLevel)
            {
                if (PlayerData.Instance.TryGetMoney(UpgradeCost))
                {
                    UpgradeRealize();
                    return true;
                }
            }

            return false;
        }
    }
}