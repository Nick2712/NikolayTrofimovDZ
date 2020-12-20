using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public class BulletController : IUpdatable
    {
        private readonly GameObject _bullet;
        private readonly float _bulletLifeTime;
        private readonly Rigidbody2D _rigidbody;
        public float Age { get; private set; }
        public bool IsActive
        {
            get
            {
                return _bullet.activeInHierarchy;
            }
        }

        public BulletController(GameObject bullet, float bulletLifeTime)
        {
            _bullet = bullet;
            _bulletLifeTime = bulletLifeTime;
            _rigidbody = _bullet.GetComponent<Rigidbody2D>();
        }

        public void BulletActivate(Vector2 force, Transform startPosition)
        {
            _rigidbody.Sleep();
            _rigidbody.WakeUp();
            Age = 0;
            _bullet.SetActive(true);
            _bullet.transform.position = startPosition.position;
            _bullet.transform.rotation = startPosition.rotation;
            _rigidbody.AddForce(force);
        }

        public void BulletDeactivate()
        {
            _bullet.SetActive(false);
        }

        public void Execute(float deltaTime)
        {
            Age += deltaTime;
            if (Age > _bulletLifeTime) BulletDeactivate();
        }
    }
}