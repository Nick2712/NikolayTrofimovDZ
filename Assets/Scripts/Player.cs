using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        [SerializeField] private float _cameraOffset = 10.0f;
        private Camera _camera;
        private Vector3 _cameraPosition;
        private Ship _ship;
        private BulletPool _bulletPool;
        private IUpdatable[] _updatables;
        private float _deltaTime;


        private void Start()
        {
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(transform, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            _ship = new Ship(moveTransform, rotation);
            _bulletPool = new BulletPool(4);
            _updatables = _bulletPool.GetBulletsArray();
        }

        private void Update()
        {
            
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            _ship.Rotation(direction);

            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                //var temAmmunition = Instantiate(_bullet, _barrel.position, _barrel.rotation);
                //temAmmunition.AddForce(_barrel.up * _force);
                _bulletPool.GetBullet(_barrel, _barrel.up * _force);
            }

            _deltaTime = Time.deltaTime;
            foreach(IUpdatable updatable in _updatables)
            {
                updatable.Execute(_deltaTime);
            }
        }

        private void LateUpdate()
        {
            SetCameraPosition();
        }

        private void SetCameraPosition()
        {
            _cameraPosition = transform.position;
            _cameraPosition.z = -_cameraOffset;
            _camera.transform.position = _cameraPosition;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _hp--;
            }
            Debug.Log("есть контакт!");
        }
    }
}
