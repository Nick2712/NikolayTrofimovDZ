using UnityEngine;

namespace Asteroids.Proxy.ProxyProtection
{
    public sealed class WeaponProxy : IWeapon
    {
        private readonly IWeapon _weapon;
        private readonly UnlockWeapon _unlockWeapon;

        public WeaponProxy(IWeapon weapon, UnlockWeapon unlockWeapon)
        {
            _weapon = weapon;
            _unlockWeapon = unlockWeapon;
        }

        public void Fire()
        {
            if (_unlockWeapon.IsUnlock)
            {
                _weapon.Fire();
            }
            else
            {
                Debug.Log("Weapon is lock");
            }
        }
    }
}
