using System;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class PlayerData : MonoBehaviour
    {
        public static PlayerData Instance { get; private set; }

        [SerializeField] private int _money = 0;

        private int _points = 0;

        public event Action OnChangeMoney;
        public event Action OnChangePoints;

        public int Money => _money;
        public int Points => _points;

        private void Awake()
        {
            Instance = this;
        }

        public void AddPoints(int count)
        {
            if (count < 0)
                return;

            _points += count;

            OnChangePoints?.Invoke();
        }
        public void AddMoney(int count)
        {
            if (count < 0)
                return;

            _money += count;

            OnChangeMoney?.Invoke();
        }
        public void AddPointsAndMoney(int count)
        {
            if (count < 0)
                return;

            _points += count;
            _money += count;

            OnChangePoints?.Invoke();
            OnChangeMoney?.Invoke();
        }
        public bool TryGetMoney(int count)
        {
            if (_money < count)
                return false;

            _money -= count;
            OnChangeMoney?.Invoke();
            return true;
        }
    }
}