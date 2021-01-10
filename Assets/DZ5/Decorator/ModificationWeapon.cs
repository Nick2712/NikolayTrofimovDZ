using UnityEngine;

namespace Asteroids.Decorator
{
    internal abstract class ModificationWeapon : IFire
    {
        private Weapon _weapon;
        private bool _modificationIsOn = false;

        protected GameObject _modification;

        protected abstract Weapon AddModification(Weapon weapon);

        protected abstract Weapon RemoveModification(Weapon weapon);

        public void ApplyModification(Weapon weapon)
        {
            if (_modificationIsOn)
            {
                _weapon = RemoveModification(weapon);
                _modificationIsOn = false;
            }
            else
            {
                _weapon = AddModification(weapon);
                _modificationIsOn = true;
            }
        }

        public void Fire()
        {
            _weapon.Fire();
        }
    }
}
