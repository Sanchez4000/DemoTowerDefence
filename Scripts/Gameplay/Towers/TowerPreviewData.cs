using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Towers
{
    public class TowerPreviewData : MonoBehaviour
    {
        [SerializeField] private Sprite _image;

        public Sprite Image => _image;
    }
}