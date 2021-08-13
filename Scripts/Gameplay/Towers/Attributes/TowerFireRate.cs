using System;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Towers.Attributes
{
    [Serializable] public class TowerFireRate : Attribute
    {
        [SerializeField] private float _value;
        [SerializeField] [Range(0, 0.15f)] private float _accelerationPercent;

        public float Value => _value;
        public float AccelerationPercent => _accelerationPercent;

        protected override void UpgradeRealize()
        {
            _value -= _value * _accelerationPercent;
            _level++;
        }
    }
}
