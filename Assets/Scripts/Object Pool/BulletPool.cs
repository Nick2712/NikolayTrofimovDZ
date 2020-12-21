using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids.Object_Pool;


namespace Asteroids
{
    public class BulletPool
    {
        private readonly Bullet[] _bulletsPool;
        private readonly Transform _bulletRootPool;

        public BulletPool(int capacityPool, float bulletLifeTime)
        {
            _bulletsPool = new Bullet[capacityPool];
            if (!_bulletRootPool)
            {
                _bulletRootPool = new GameObject(NameManager.BULLET_POOL_AMMUNITION).transform;
            }

            var bullet = Resources.Load<GameObject>("Bullets/Bullet");
            for (int i = 0; i < _bulletsPool.Length; i++)
            {
                var instantiate = UnityEngine.Object.Instantiate(bullet);
                var bulletController = new Bullet(instantiate, bulletLifeTime);
                ReturnToPool(instantiate.transform);
                _bulletsPool[i] = bulletController;
            }
        }

        private void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_bulletRootPool);
        }

        public Bullet GetBullet(Transform startPosition, Vector2 force)
        {
            int currentBulletInPool = 0;
            int oldestBulletIndex = 0;
            while(currentBulletInPool < _bulletsPool.Length)
            {
                if(!_bulletsPool[currentBulletInPool].IsActive)
                {
                    return LaunchBullet(_bulletsPool[currentBulletInPool], startPosition, force);
                }
                if(_bulletsPool[oldestBulletIndex].Age < _bulletsPool[currentBulletInPool].Age)
                {
                    oldestBulletIndex = currentBulletInPool;
                }
                currentBulletInPool++;
            }
            return LaunchBullet(_bulletsPool[oldestBulletIndex], startPosition, force);
        }

        public Bullet LaunchBullet(Bullet bullet, Transform startPosition, Vector2 force)
        {
            bullet.BulletActivate(force, startPosition);
            return bullet;
        }

        public Bullet[] GetBulletsArray()
        {
            return _bulletsPool;
        }
    }
}