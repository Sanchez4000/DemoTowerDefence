using System;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Towers.Attributes
{
    [Serializable] public class TowerDamage : Attribute
    {
        [SerializeField] private int _value;
        [SerializeField] private int _boostPerUpgrade;

        public int Value => _value;
        public int BoostPerUpgrade => _boostPerUpgrade;

        protected override void UpgradeRealize()
        {
            _value += _boostPerUpgrade;
            _level++;
        }
    }
}
