using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public class Bullet : MonoBehaviour, IUpdatable
    {
        [SerializeField] private float _bulletLifeTime = 5.0f;
        private Rigidbody2D _rigidbody;
        public float Age { get; private set; }
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void BulletActivate(Vector2 force)
        {
            _rigidbody.Sleep();
            _rigidbody.WakeUp();
            Age = 0;
            gameObject.SetActive(true);
            _rigidbody.AddForce(force);
        }

        public void BulletDeactivate()
        {
            gameObject.SetActive(false);
        }

        public void Execute(float deltaTime)
        {
            Age += deltaTime;
            if (Age > _bulletLifeTime) BulletDeactivate();
        }
    }
}