using System;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Towers.Attributes
{
    [Serializable] public class TowerRewardMultiplier : Attribute
    {
        [SerializeField] private float _value;
        [SerializeField] private float _boostPerUpgrade;

        public float Value => _value;
        public float BoostPerUpgrade => _boostPerUpgrade;

        protected override void UpgradeRealize()
        {
            _value += _boostPerUpgrade;
            _level++;
        }
    }
}
