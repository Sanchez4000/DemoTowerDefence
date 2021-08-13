using System;
using UnityEngine;
using TMPro;
using Attribute = Assets.Scripts.Gameplay.Towers.Attributes.Attribute;

namespace Assets.Scripts.UI.Windows.TowerPropertyWindowInternal
{
    [Serializable] public class AttributeUpgradeField
    {
        [SerializeField] private TextMeshProUGUI _level;
        [SerializeField] private TextMeshProUGUI _cost;

        public void UpdateValues(Attribute attribute)
        {
            _level.text = $"LV: {attribute.Level}";
            _cost.text = attribute.Level < attribute.MaxLevel ? $"{attribute.UpgradeCost}$" : "MAX!";
        }
    }
}
