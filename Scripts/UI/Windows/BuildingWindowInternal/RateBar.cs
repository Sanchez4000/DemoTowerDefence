using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.BuildingWindowInternal
{
    [Serializable] public class RateBar
    {
        [SerializeField] [Range(0, 5)] private int _rate = 0;
        [SerializeField] private Image[] _star = new Image[5];
        [SerializeField] private Color _enableStarColor = new Color(0, 1, 0);
        [SerializeField] private Color _disableStarColor = new Color(1, 0, 0);

        public void Initialize()
        {
            for (int i = 0; i < _star.Length; i++)
            {
                _star[i].color = i < _rate ? _enableStarColor : _disableStarColor;
            }
        }
    }
}