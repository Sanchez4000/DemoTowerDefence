using UnityEngine;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Windows;

namespace Assets.Scripts.Gameplay
{
    public class TowerContainerClickHandler : MonoBehaviour
    {
        private TowerContainer _towerContainer = null;

        private void Start()
        {
            _towerContainer = GetComponent<TowerContainer>();
            if (_towerContainer == null)
                throw new System.Exception($"TowerContainer in {name} is null!");
        }
        private void OnMouseUpAsButton()
        {
            if (_towerContainer.Tower == null)
            {
                if (GameplayUI.Instance.AnyWindowIsOpened)
                    return;

                BuildingWindow buildingWindow = GameplayUI.Instance.GetWindow<BuildingWindow>();
                buildingWindow.SetTargetCell(_towerContainer);
                buildingWindow.Open();
            }
        }
    }
}