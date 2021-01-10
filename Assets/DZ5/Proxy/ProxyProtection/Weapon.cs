using UnityEngine;

namespace Asteroids.Proxy.ProxyProtection
{
    public sealed class Weapon : IWeapon
    {
        public void Fire()
        {
            Debug.Log("Fire");
        }
    }
}
