using UnityEngine;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Windows;

namespace Assets.Scripts.Gameplay.Towers
{
    public class TowerClickHandler : MonoBehaviour
    {
        private Tower _tower = null;

        private void Start()
        {
            _tower = GetComponent<Tower>();
            if (_tower == null)
                throw new System.Exception($"Can't find \"Tower\" component in {name}!");
        }

        private void OnMouseUpAsButton()
        {
            if (GameplayUI.Instance.AnyWindowIsOpened)
                return;

            TowerPropertyWindow propertyWindow = GameplayUI.Instance.GetWindow<TowerPropertyWindow>();
            propertyWindow.SetInspectedTower(_tower);
            propertyWindow.Open();
        }
    }
}