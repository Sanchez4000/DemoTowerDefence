using UnityEngine;

namespace Assets.Scripts.Gameplay.Towers.TowerShoting
{
    public class DualShot : ShotAction
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _firstBulletStartPoint;
        [SerializeField] private Transform _secondBulletStartPoint;

        public override void Shot(Tower source)
        {
            Bullet[] createdBullets = new Bullet[2];
            TowerDamageData damageData = new TowerDamageData(source.Attributes.Damage.Value, source);
            Vector3 direction = transform.forward;
            for (int i = 0; i < createdBullets.Length; i++)
            {
                createdBullets[i] = Instantiate(_bulletPrefab);
                Vector3 startPosition = i == 0 ? _firstBulletStartPoint.position : _secondBulletStartPoint.position;
                createdBullets[i].Initialize(startPosition, direction, damageData);
            }
        }
    }
}