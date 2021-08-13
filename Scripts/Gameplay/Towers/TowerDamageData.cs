using System;

namespace Assets.Scripts.Gameplay.Towers
{
    public class TowerDamageData
    {
        private int _damage;
        private Tower _source;

        public int Damage => _damage;
        public Tower Source => _source;

        public TowerDamageData(int damage, Tower source)
        {
            _damage = damage;
            _source = source;
        }
        public void SetData(int damage, Tower source)
        {
            _damage = damage;
            _source = source;
        }
    }
}
