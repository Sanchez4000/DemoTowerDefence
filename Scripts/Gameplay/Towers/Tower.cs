using System;
using UnityEngine;
using Assets.Scripts.Gameplay.Enemys;
using Assets.Scripts.Gameplay.Towers.TowerShoting;

namespace Assets.Scripts.Gameplay.Towers
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private ShotAction _shotAction;
        [SerializeField] private RaycastFinder _enemyFinder;
        [SerializeField] private TowerAttributes _attributes;

        private bool _isSeeingEnemy = false;
        private float _reloadTimer = 0f;

        private bool CanShooting => _reloadTimer <= 0;

        public TowerAttributes Attributes => _attributes;

        private void Update()
        {
            if (_shotAction == null)
                return;

            if (_reloadTimer > 0)
                _reloadTimer -= Time.deltaTime;

            if (_isSeeingEnemy)
            {
                if (CanShooting)
                {
                    _shotAction.Shot(this);
                    _reloadTimer = _attributes.FireRate.Value;
                }
            }
        }
        private void FixedUpdate()
        {
            Enemy[] allFindedEnemys = _enemyFinder.FindAllObjectsOfType<Enemy>(transform.forward);
            _isSeeingEnemy = (allFindedEnemys != null);
        }

        public void TakeDamage(int damage)
        {
            _attributes.Health.TakeDamage(damage);
            if (_attributes.Health.Current <= 0)
                TowerDestroyer.Destroy(this);
        }
    }
} 