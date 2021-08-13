using UnityEngine;

namespace Assets.Scripts.Gameplay.Enemys
{
    public class EnemyAttributes : MonoBehaviour
    {
        [SerializeField] private int _level = 0;
        [SerializeField] private EnemyHealth _health;
        [SerializeField] private EnemyDamage _damage;
        [SerializeField] private EnemyAttackSpeed _attackDelay;
        [SerializeField] private float _attackDistance = 2.5f;
        [SerializeField] private float _moveSpeed = 2.5f;
        [SerializeField] private int _reward = 2;

        public int Level => _level;
        public EnemyHealth Health => _health;
        public EnemyDamage Damage => _damage;
        public EnemyAttackSpeed AttackDelay  => _attackDelay; 
        public float AttackDistance => _attackDistance;
        public float MoveSpeed => _moveSpeed;
        public int Reward => _reward;

        public void InitializeAttributes()
        {
            _health.SetHealth(_level);
            _damage.SetDamage(_level);
            _attackDelay.SetAttackSpeed(_level);
        }
        public void SetLevel(int level)
        {
            _level = level;
        }
    }
}