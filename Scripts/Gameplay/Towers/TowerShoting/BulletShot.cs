using UnityEngine;

namespace Assets.Scripts.Gameplay.Towers.TowerShoting
{
    public class BulletShot : ShotAction
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _shotStartPoint;

        public override void Shot(Tower source)
        {
            Bullet bullet = Instantiate(_bulletPrefab);
            TowerDamageData damageData = new TowerDamageData(source.Attributes.Damage.Value, source);
            bullet.Initialize(_shotStartPoint.position, transform.forward, damageData);
        }
    }
}