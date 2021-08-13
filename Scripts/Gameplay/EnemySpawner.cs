using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Gameplay.Enemys;

namespace Assets.Scripts.Gameplay
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyCollection _enemyCollection;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float _minSpawnDelayTime = 1f;
        [SerializeField] private float _maxSpawnDelayTime = 5f;

        private float _spawnDelay = 0f;
        private bool _isActive = false;

        public bool IsActive 
        {
            get => _isActive;
            set
            {
                _isActive = value;
                if (_isActive)
                    _spawnDelay = Random.Range(_minSpawnDelayTime, _maxSpawnDelayTime);
            }
        }

        private void Start()
        {
            TimeOfDay.Instance.OnStateChanged += ChangeState;
        }
        private void Update()
        {
            if (_isActive)
            {
                if (_spawnDelay <= 0)
                {
                    Spawn();
                    _spawnDelay = Random.Range(_minSpawnDelayTime, _maxSpawnDelayTime);
                }
                else
                {
                    _spawnDelay -= Time.deltaTime;
                }
            }
        }
        private void OnDisable()
        {
            TimeOfDay.Instance.OnStateChanged -= ChangeState;
        }

        private void Spawn()
        {
            List<Enemy> avaibleSpawnEnemys = new List<Enemy>();
            foreach (var item in _enemyCollection.Data)
            {
                if (TimeOfDay.Instance.CurrentDay >= item.MinSpawnDay)
                {
                    avaibleSpawnEnemys.Add(item.Prefab);
                }
            }

            int enemyIndex = Random.Range(0, avaibleSpawnEnemys.Count);
            Enemy newEnemy = Instantiate(avaibleSpawnEnemys[enemyIndex]);
            newEnemy.transform.position = _spawnPoint.position;
        }
        private void ChangeState()
        {
            _isActive = TimeOfDay.Instance.DayState == DayState.Day;

            if (_isActive)
                _spawnDelay = Random.Range(_minSpawnDelayTime, _maxSpawnDelayTime);
        }
    }
}