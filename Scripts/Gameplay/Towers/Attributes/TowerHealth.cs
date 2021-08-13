using System;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Towers.Attributes
{
    [Serializable] public class TowerHealth : Attribute
    {
        [SerializeField] private int _current;
        [SerializeField] private int _max;
        [SerializeField] private int _boostPerUpgrade;

        public int Current => _current;
        public int Max => _max;
        public int BoostPerUpgrade => _boostPerUpgrade;

        protected override void UpgradeRealize()
        {
            float healthPercent = (float)_current / (float)_max;
            _max += _boostPerUpgrade;
            _current = (int)(_max * healthPercent);
            _level++;
        }

        public void TakeDamage(int value)
        {
            if (value >= 0)
                _current -= value;
        }
        public void Restore(int value)
        {
            if (value >= 0)
                if ((_current += value) > _max)
                    _current = _max;
        }
    }
}
