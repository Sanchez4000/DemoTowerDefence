using Assets.Scripts.Gameplay;
using Assets.Scripts.Gameplay.Towers;

namespace Assets.Scripts.UI.Windows
{
    public class BuildingWindow : Window
    {
        private TowerContainer _targetContainer = null;

        private void OnEnable()
        {
            if (_targetContainer == null)
                throw new System.Exception($"Null Reference \"TowerContainer\" in {this}");
        }
        private void OnDisable()
        {
            _targetContainer = null;
        }

        public void SetTargetCell(TowerContainer target)
        {
            _targetContainer = target;
        }
        public void Build(Tower prefab)
        {
            _targetContainer.Build(prefab);
            Close();
        }
    }
}