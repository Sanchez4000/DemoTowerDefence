using System;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Enemys
{
    [Serializable] public class EnemyAttackSpeed
    {
        [SerializeField] private float _value;
        [SerializeField] [Range(0, 1f)] private float _accelerationPercent;

        public float Value => _value;
        public float AccelerationPercent => _accelerationPercent;

        public void SetAttackSpeed(int level)
        {
            _value *= Mathf.Pow((1 - _accelerationPercent), level);
        }
        public void Upgrade()
        {
            _value *= 1 - _accelerationPercent;
        }
    }
}
