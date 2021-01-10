using UnityEngine;

namespace Asteroids.Decorator
{
    internal sealed class ModificationMuffler : ModificationWeapon
    {
        private readonly AudioSource _audioSource;
        private readonly IMuffler _muffler;
        private readonly Vector3 _mufflerPosition;
        private readonly Transform _barrelPositionWithoutMufler;
        private readonly AudioClip _audioClipWithoutMufler;
        private readonly float _volumeFireWithoutMufler;

        public ModificationMuffler(AudioSource audioSource, IMuffler muffler, Vector3 mufflerPosition,
            Transform barrelPositionWithoutMufler, AudioClip audioClipWithoutMufler,
            float volumeFireWithoutMufler)
        {
            _audioSource = audioSource;
            _muffler = muffler;
            _mufflerPosition = mufflerPosition;
            _barrelPositionWithoutMufler = barrelPositionWithoutMufler;
            _audioClipWithoutMufler = audioClipWithoutMufler;
            _volumeFireWithoutMufler = volumeFireWithoutMufler;
        }

        protected override Weapon AddModification(Weapon weapon)
        {
            _modification = Object.Instantiate(_muffler.MufflerInstance, _mufflerPosition, Quaternion.identity);
            _audioSource.volume = _muffler.VolumeFireOnMuffler;
            weapon.SetAudioClip(_muffler.AudioClipMuffler);
            weapon.SetBarrelPosition(_muffler.BarrelPositionMuffler);
            return weapon;
        }

        protected override Weapon RemoveModification(Weapon weapon)
        {
            Object.Destroy(_modification);
            _audioSource.volume = _volumeFireWithoutMufler;
            weapon.SetAudioClip(_audioClipWithoutMufler);
            weapon.SetBarrelPosition(_barrelPositionWithoutMufler);
            return weapon;
        }
    }
}
