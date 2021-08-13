using UnityEngine;
using Assets.Scripts.Gameplay.Towers;
using Assets.Scripts.Gameplay.Enemys;

namespace Assets.Scripts.Gameplay
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;

        private Vector3 _moveDirection = Vector3.forward;
        private TowerDamageData _damageData;

        private void Update()
        {
            Vector3 newPosition = transform.position + _moveDirection * _moveSpeed * Time.deltaTime;
            transform.position = newPosition;
        }
        private void OnTriggerEnter(Collider other)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(_damageData);
            }
            Destroy(gameObject);
        }

        public void Initialize(TowerDamageData damageData)
        {
            _damageData = damageData;
        }
        public void Initialize(Vector3 position, Vector3 direction, TowerDamageData damageData)
        {
            transform.position = position;
            _moveDirection = direction;
            _damageData = damageData;
        }
        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }
        public void SetDirection(Vector3 direction)
        {
            _moveDirection = direction;
        }
    }
}