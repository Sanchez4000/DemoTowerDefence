using UnityEngine;
using Assets.Scripts.Gameplay.Towers;

namespace Assets.Scripts.Gameplay.Enemys
{ 
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private RaycastFinder _towerFinder;
        [SerializeField] private EnemyAttributes _attributes;

        private Tower _nearestTower = null;
        private float _attackPauseTimer = 0f;

        private bool CanAttack => _attackPauseTimer <= 0f;
        public EnemyAttributes Attributes => _attributes;

        private void Start()
        {
            _attributes.SetLevel(TimeOfDay.Instance.CurrentDay / GameDifficultyData.Instance.DaysPerEnemyLevel);
            _attributes.InitializeAttributes();
        }
        private void Update()
        {
            if (_attackPauseTimer > 0f)
                _attackPauseTimer -= Time.deltaTime;

            if (_nearestTower != null)
            {
                float distance = Vector3.Distance(transform.position, _nearestTower.transform.position);
                if (distance <= _attributes.AttackDistance)
                {
                    if (CanAttack)
                    {
                        Attack();
                        _attackPauseTimer = _attributes.AttackDelay.Value;
                    }
                }
                else
                {
                    MoveForward();
                }
            }
            else
            {
                MoveForward();
            }
        }
        private void FixedUpdate()
        {
            Tower[] allFindedTowers = _towerFinder.FindAllObjectsOfType<Tower>(transform.forward);
            _nearestTower = FindNearestTower(allFindedTowers);
        }

        private Tower FindNearestTower(Tower[] towersArray)
        {
            if (towersArray == null)
                return null;

            if (towersArray.Length == 0)
                return null;

            float minDistance = float.PositiveInfinity;
            int nearestTowerIndex = 0;
            for (int i = 0; i < towersArray.Length; i++)
            {
                float distance = Vector3.Distance(transform.position, towersArray[i].transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestTowerIndex = i;
                }
            }

            return towersArray[nearestTowerIndex];
        }
        private void MoveForward()
        {
            transform.position = transform.position + transform.forward * _attributes.MoveSpeed * Time.deltaTime;
        }
        private void Attack()
        {
            _nearestTower.TakeDamage(_attributes.Damage.Value);
        }

        public void TakeDamage(TowerDamageData damageData)
        {
            _attributes.Health.TakeDamage(damageData.Damage);
            if (_attributes.Health.Current <= 0)
            {
                float reward = _attributes.Reward * damageData.Source.Attributes.RewardMultiplier.Value;
                PlayerData.Instance.AddPointsAndMoney((int)reward);
                Destroy(gameObject);
            }
        }
    }
}