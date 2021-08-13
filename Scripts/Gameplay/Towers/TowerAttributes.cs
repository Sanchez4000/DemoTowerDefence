using UnityEngine;
using Assets.Scripts.Gameplay.Towers.Attributes;

namespace Assets.Scripts.Gameplay.Towers
{
    public class TowerAttributes : MonoBehaviour
    {
        [SerializeField] private TowerHealth _health;
        [SerializeField] private TowerDamage _damage;
        [SerializeField] private TowerFireRate _fireRate;
        [SerializeField] private TowerRewardMultiplier _rewardMultiplier;
        [SerializeField] private int _baseCost;

        public TowerHealth Health => _health;
        public TowerDamage Damage => _damage;
        public TowerFireRate FireRate => _fireRate;
        public TowerRewardMultiplier RewardMultiplier => _rewardMultiplier;
        public int BaseCost => _baseCost;
    }
} 