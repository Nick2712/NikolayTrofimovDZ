using UnityEngine;

namespace Asteroids.Proxy.ProxyProtection
{
    internal sealed class Example : MonoBehaviour
    {
        private void Start()
        {
            var unlockWeapon = new UnlockWeapon(false);
            var weapon = new Weapon();
            var weaponProxy = new WeaponProxy(weapon, unlockWeapon);
            weaponProxy.Fire();
            unlockWeapon.IsUnlock = true;
            weaponProxy.Fire();
        }
    }
}
