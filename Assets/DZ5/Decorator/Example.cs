using UnityEngine;

namespace Asteroids.Decorator
{
    internal sealed class Example : MonoBehaviour
    {
        private IFire _fire;
        [Header("Start Gun")]
        [SerializeField] private Rigidbody _bullet;
        [SerializeField] private Transform _barrelPosition;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        private readonly float _volumeFire = 1.0f;

        [Header("Muffler Gun")] 
        [SerializeField] private AudioClip _audioClipMuffler;
        [SerializeField] private float _volumeFireOnMuffler = 0.5f;
        [SerializeField] private Transform _barrelPositionMuffler;
        [SerializeField] private GameObject _muffler;

        [Header("Scope Gun")]
        [SerializeField] private GameObject _scope;

        private Weapon _weaponWithoutModification;
        private ModificationWeapon _modificationMuffler;
        private ModificationWeapon _modificationScope;

        private void Start()
        {
            IAmmunition ammunition = new Bullet(_bullet, 3.0f);
            _weaponWithoutModification = new Weapon(ammunition, _barrelPosition, 999.0f, _audioSource, _audioClip);

            var muffler = new Muffler(_audioClipMuffler, _volumeFireOnMuffler, _barrelPosition, _muffler);
            _modificationMuffler = new ModificationMuffler(_audioSource, muffler, _barrelPositionMuffler.position,
                _barrelPosition, _audioClip, _volumeFire);
            
            var scope = new Scope(_scope);
            _modificationScope = new ModificationScope(scope);

            _fire = _weaponWithoutModification;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _fire.Fire();
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _modificationMuffler.ApplyModification(_weaponWithoutModification);
            }

            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                _modificationScope.ApplyModification(_weaponWithoutModification);
            }
        }
    }
}
