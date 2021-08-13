using System;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Enemys
{
    [Serializable] public class EnemyDamage
    {
        [SerializeField] private int _value;
        [SerializeField] private int _amplificationPerLevel;

        public int Value => _value;
        public int AmplificationPerLevel => _amplificationPerLevel;

        public void SetDamage(int level)
        {
            _value += level * _amplificationPerLevel;
        }
        public void Upgrade()
        {
            _value += _amplificationPerLevel;
        }
    }
}
