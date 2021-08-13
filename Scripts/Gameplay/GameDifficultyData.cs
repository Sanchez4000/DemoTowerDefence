using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class GameDifficultyData : MonoBehaviour
    {
        public static GameDifficultyData Instance { get; private set; }

        [SerializeField] private int _daysPerEnemyLevel = 3;

        public int DaysPerEnemyLevel => _daysPerEnemyLevel;

        private void Awake()
        {
            Instance = this;
        }
    }
}