using UnityEngine;

namespace Assets.Scripts.Gameplay.Towers.TowerShoting
{

    public abstract class ShotAction : MonoBehaviour
    {
        public abstract void Shot(Tower source);
    }
}