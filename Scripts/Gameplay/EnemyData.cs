using System;
using UnityEngine;
using Assets.Scripts.Gameplay.Enemys;

namespace Assets.Scripts.Gameplay
{
    [Serializable] public class EnemyData
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField] private int _minSpawnDay;

        public Enemy Prefab => _prefab;
        public int MinSpawnDay => _minSpawnDay;
    }
}