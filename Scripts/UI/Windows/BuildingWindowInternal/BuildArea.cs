using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Gameplay;
using Assets.Scripts.Gameplay.Towers;
using Assets.Scripts.UI.BuildingWindowInternal;

namespace Assets.Scripts.UI.Windows.BuildingWindowInternal
{
    public class BuildArea : MonoBehaviour
    {
        [SerializeField] private BuildingWindow _buildingWindow;
        [SerializeField] private Tower _prefab;
        [SerializeField] private Image _preview;
        [SerializeField] private RateBar _damage;
        [SerializeField] private RateBar _health;
        [SerializeField] private RateBar _fireRate;
        [SerializeField] private RateBar _reward;
        [SerializeField] private TextMeshProUGUI _cost;

        private void Start()
        {
            RateBar[] allRateBars = { _damage, _health, _fireRate, _reward };
            foreach (var item in allRateBars)
            {
                item.Initialize();
            }

            _preview.sprite = _prefab.GetComponent<TowerPreviewData>().Image;
            _cost.text = $"{_prefab.Attributes.BaseCost}$";
        }

        public void Build()
        {
            if (PlayerData.Instance.TryGetMoney(_prefab.Attributes.BaseCost)) 
            {
                _buildingWindow.Build(_prefab);                
            }
        }
    }
}