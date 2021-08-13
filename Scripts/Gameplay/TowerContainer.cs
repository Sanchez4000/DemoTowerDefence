using UnityEngine;
using Assets.Scripts.Gameplay.Towers;

namespace Assets.Scripts.Gameplay
{
    public class TowerContainer : MonoBehaviour
    {
        [SerializeField] private Transform _towerPivotPoint;

        private Tower _tower = null;

        public Tower Tower => _tower;

        private void Start()
        {
            name = $"cell[{transform.position.x},{transform.position.z}]";
        }

        public void SetOwnedTower(Tower tower)
        {
            _tower = tower;
        }
        public void Build(Tower prefab)
        {
            if (_tower != null)
                throw new System.Exception($"The tower already exists in {name}");
            
            Tower buildTower = Instantiate(prefab);
            buildTower.transform.position = _towerPivotPoint.position;
            _tower = buildTower;
        }
    }
}