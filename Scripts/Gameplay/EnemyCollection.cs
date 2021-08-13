using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Gameplay.Enemys;

namespace Assets.Scripts.Gameplay
{
    [CreateAssetMenu(fileName = "NewEnemyCollection", menuName = "NewEnemyCollection")]
    public class EnemyCollection : ScriptableObject
    {
        [SerializeField] private List<EnemyData> _data;

        public List<EnemyData> Data => _data;
    }
}