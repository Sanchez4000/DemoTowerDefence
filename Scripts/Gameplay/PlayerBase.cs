using System;
using UnityEngine;
using Assets.Scripts.Gameplay.Enemys;
using Assets.Scripts.Gameplay.Towers;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Windows;

namespace Assets.Scripts.Gameplay
{
    public class PlayerBase : MonoBehaviour
    {
        public static PlayerBase Instance { get; private set; }

        public const int MaxHealth = 100;

        [SerializeField] private int _health = MaxHealth;
        [SerializeField] private int _damagePerEnemy = 10;

        public int Health => _health;

        public event Action OnHealthChanged;

        private void Awake()
        {
            Instance = this;
        }
        private void OnTriggerEnter(Collider other)
        {
            Enemy contactedEnemy = other.GetComponent<Enemy>();
            if (contactedEnemy != null)
            {
                TakeDamage();
                Destroy(contactedEnemy.gameObject);
            }
        }

        private void TakeDamage()
        {
            _health -= _damagePerEnemy;
            OnHealthChanged?.Invoke();
            if (_health <= 0)
            {
                EndGame();
            }
        }
        private void EndGame()
        {
            Enemy[] allEnemys = GameObject.FindObjectsOfType<Enemy>();
            foreach (var item in allEnemys)
            {
                Destroy(item.gameObject);
            }

            Tower[] allTowers = GameObject.FindObjectsOfType<Tower>();
            foreach (var item in allTowers)
            {
                item.Destroy();
            }

            var window = GameplayUI.Instance.GetWindow<EndGameWindow>();
            window.Open();
        }
    }
}