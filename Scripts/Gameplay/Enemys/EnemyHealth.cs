using System;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Enemys
{
    [Serializable] public class EnemyHealth
    {
        [SerializeField] private int _current;
        [SerializeField] private int _max;
        [SerializeField] private int _amplificationPerLevel;

        public int Current => _current;
        public int Max => _max;
        public int AmplificationPerLevel => _amplificationPerLevel;

        public void SetHealth(int level)
        {
            _max += level * _amplificationPerLevel;
            _current = _max;
        }
        public void TakeDamage(int value)
        {
            if (value > 0)
                _current -= value;
        }
        public void Restore(int value)
        {
            if (value > 0)
                if ((_current += value) > _max)
                    _current = _max;
        }
        public void Upgrade()
        {
            float healthPercent = (float)_current / (float)_max;
            _max += _amplificationPerLevel;
            _current = (int)(_max * healthPercent);
        }
    }
}
